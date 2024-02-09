using System.ComponentModel.Design;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment3
{
    internal class Program
    {
        public static int mainMenu()
        {
            Console.WriteLine("Main Menu:\n" +
                "1. Area calculation\n" +
                "2. Perimeter calculation\n" +
                "3. Exit");
            int returnValue;
            do
            {
                Console.WriteLine("Enter your choice :");
                returnValue = int.Parse(Console.ReadLine());
            } while (returnValue > 3);
            return returnValue;
        }
        public static int subMenu()
        {
            Console.WriteLine("Secondary menu for figure choice:\n" +
                "1. Square\n" +
                "2. Rectangular\n" +
                "3. Triangle\n" +
                "4. Circle\n" +
                "5. Main Menu");
            int returnValue;
            do
            {
                Console.WriteLine("Enter your choice:");
                returnValue = int.Parse(Console.ReadLine());
            } while (returnValue > 5);
            return returnValue;
        }
        public static int mainMenuChoice(ref int number)
        {
            int result = 0;
            if (number == 1 || number == 2)
            {
                result = subMenu();
            }
            else if (number == 3)
            {
                char answer;
                do
                {
                    Console.WriteLine("Do you wanna leave?(y/n)");
                    answer = char.Parse(Console.ReadLine());
                } while (answer != 'y' && answer != 'n');
                if (answer == 'y')
                {
                    Console.WriteLine("You exited program!");
                }
                else if (answer == 'n')
                {
                    number = mainMenu();
                    result = mainMenuChoice(ref number);
                }
            }
            return result;
        }
        public static void subMenuChoice(int mainMenuValue, int subMenuValue)
        {
            float result = 0;
            if (subMenuValue == 1)
            {
                float side = square();
                if (mainMenuValue == 1) { result = squareArea(side); }
                else if (mainMenuValue == 2) { result = squarePerimeter(side); }
                Console.WriteLine($"Final result:{result}");
                check(mainMenuValue, subMenuValue);
            }
            if (subMenuValue == 2)
            {
                float length;
                float width = rectangular(out length);
                if (mainMenuValue == 1) { result = rectangularArea(width, length); }
                else if (mainMenuValue == 2) { result = rectangularPerimeter(width, length); }
                Console.WriteLine($"Final result:{result}");
                check(mainMenuValue, subMenuValue);
            }
            if (subMenuValue == 3)
            {
                float side2, side3;
                float side1 = triangle(out side2, out side3);
                if (mainMenuValue == 1) { result = triangleArea(side1, side2, side3); }
                else if (mainMenuValue == 2) { result = trianglePerimeter(side1, side2, side3); }
                Console.WriteLine($"Final result:{result}");
                check(mainMenuValue, subMenuValue);
            }
            if (subMenuValue == 4)
            {
                float radius = circle();
                if (mainMenuValue == 1) { result = circleArea(radius); }
                else if (mainMenuValue == 2) { result = circlePerimeter(radius); }
                Console.WriteLine($"Final result:{result}");
                check(mainMenuValue, subMenuValue);
            }
            if (subMenuValue == 5)
            {
                mainMenuValue = mainMenu();
                subMenuValue = mainMenuChoice(ref mainMenuValue);
                subMenuChoice(mainMenuValue, subMenuValue);
            }
        }
        public static void check(int number1, int number2)
        {
            char answer;
            do
            {
                Console.WriteLine("Do you wanna continue with the same figure?(y/n)");
                answer = char.ToLower(char.Parse(Console.ReadLine()));
            } while (answer != 'y' && answer != 'n');
            if (answer == 'y')
            {
                subMenuChoice(number1, number2);
            }
            else
            {
                int newSubMenuChoice = subMenu();
                subMenuChoice(number1, newSubMenuChoice);
            }
        }
        public static float square()
        {
            float side;
            do
            {
                Console.WriteLine("Enter a side of the square:");
                side = float.Parse(Console.ReadLine());
            } while (side < 0);
            return side;
        }
        public static float circle()
        {
            float radius;
            do
            {
                Console.WriteLine("Enter the radius of the circle:");
                radius = float.Parse(Console.ReadLine());
            } while (radius < 0);
            return radius;
        }
        public static float rectangular(out float width)
        {
            float length;
            do
            {
                Console.WriteLine("Enter the width of the rectangular:");
                width = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter the length of the rectangular:");
                length = float.Parse(Console.ReadLine());
            } while (width < 0 && length < 0);
            return length;
        }
        public static float triangle(out float side1, out float side2)
        {
            float side3;
            do
            {
                Console.WriteLine("Enter first side of the tirangle:");
                side1 = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter second side of the tirangle:");
                side2 = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter third side of the tirangle:");
                side3 = float.Parse(Console.ReadLine());
            } while (side1 < 0 && side2 < 0 && side3 < 0);
            return side3;
        }
        public static float squareArea(float side)
        {
            return side * side;
        }
        public static float squarePerimeter(float side)
        {
            return side * 4;
        }
        public static float rectangularArea(float width, float length)
        {
            return width * length;
        }
        public static float rectangularPerimeter(float width, float length)
        {
            return 2 * (width + length);
        }
        public static float triangleArea(float side1, float side2, float side3)
        {
            float pHalf = trianglePerimeter(side1, side2, side3) / (float)2;
            float area = (float)Math.Sqrt(pHalf * (pHalf - side1) * (pHalf - side2) * (pHalf - side3));
            return area;
        }
        public static float trianglePerimeter(float side1, float side2, float side3)
        {
            return side1 + side2 + side3;
        }
        public static float circlePerimeter(float radius)
        {
            return 2 * (float)Math.PI * radius;
        }
        public static float circleArea(float radius)
        {
            return (float)Math.PI * radius * radius;
        }
        static void Main(string[] args)
        {
            int mainMenuvalue = mainMenu();
            int subMenuValue = mainMenuChoice(ref mainMenuvalue);
            subMenuChoice(mainMenuvalue, subMenuValue);
        }
    }
}