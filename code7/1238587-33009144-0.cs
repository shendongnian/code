    //Develop a menu-driven program that inputs a number X and, at the user’s option, 
    //finds the area of a square with side x [Area = x2], the area of a circle with radius X [Area = 3.14 * x2],
    //or the area of an equilateral triangle with side x [Area = Sqrt(3) / 4 * X2]. 
    //Use a case structure to handle the user’s menu choice. Use the Sqrt method in the C# Math library.
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int a = 0;
                double b = 0;
    
                Console.Write("Enter 1 for Area of square :\nEnter 2 For Area of Circle :\nEnter 3 for Equilateral Triangle :\n\n");
                aa:
                a = int.Parse(Console.ReadLine());
    
                switch (a)
                {
                    case 1: 
                        Console.Write("\n\nEnter the Value of Side x : ");
                        b = double.Parse(Console.ReadLine());
                        double area = b * b;
                        Console.Write("\n\nThe area of square is {0}",area);
                        break;
    
                    case 2:
                         Console.Write("\n\nEnter the Value of Side x : ");
                        b = double.Parse(Console.ReadLine());
                        double circle = (3.14) * (Math.Pow(b, 2));
                        Console.Write("\n\nThe Area of Circle is {0}",circle);
                        break;
    
                    case 3:
                         Console.Write("\n\nEnter the Value of Side x : ");
                        b = double.Parse(Console.ReadLine());
                        double triangle = ((Math.Sqrt(3)) / 4) * (Math.Pow(b, 2));
                        Console.Write("\n\nThe Area of Triangle is {0}",triangle);
                        break;
    
                    default:
                        Console.Write("\n\nEnter Correct Number : ");
                        goto aa;                    
                }
                Console.Read();
            }
        }
    }
