    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> studentInfoName = new List<string>();
                List<int> studentInfoClassAndNumber = new List<int>();
                while(true)
                {
                    DrawStarLine();
                    DrawTitle();
                    DrawMenu();
                    int answer = int.Parse(Console.ReadLine());
                    if (answer == 1)
                    {
                        Console.WriteLine("Enter information about a student");
                        Console.Write("Name: ");
                        studentInfoName.Add(Console.ReadLine());
                        Console.Write("Middle name: ");
                        studentInfoName.Add(Console.ReadLine());
                        Console.Write("Last name: ");
                        studentInfoName.Add(Console.ReadLine());
                        Console.Write("Class ");
                        studentInfoClassAndNumber.Add(int.Parse(Console.ReadLine()));
                        Console.Write("Number ");
                        studentInfoClassAndNumber.Add(int.Parse(Console.ReadLine()));
                    }
                    else if (answer == 2)
                    {
                        Console.WriteLine("Student Information");
                        foreach(String nextEntry in studentInfoName)
                        {
                            Console.WriteLine(nextEntry);
                        }
                        
                        Console.WriteLine("Course Information");
                        foreach(String nextEntry in studentInfoClassAndNumber)
                        {
                            Console.WriteLine(nextEntry);
                        }
                        
                    }
                    else if(answer == 3)
                    {
                        return 0;
                    else
                    {
                        ErrorMessage();
                    }
                    Console.ReadKey();
                }
            }
            private static void ErrorMessage()
            {
                Console.WriteLine("Typing error, press key to continue.");
            }
            private static void DrawStarLine()
            {
                Console.WriteLine("************************");
            }
            private static void DrawTitle()
            {
                DrawStarLine();
                Console.WriteLine("+++ Student Information Database +++");
                DrawStarLine();
            }
            private static void DrawMenu()
            {
                DrawStarLine();
                Console.WriteLine(" 1. Enter information about a student.");
                Console.WriteLine(" 2. Retrieve information about a student available in the program");
                Console.WriteLine(" 3. Exit from the program");
                DrawStarLine();
                Console.WriteLine("Make your choice: type 1, 2, or 3 for exit");
                DrawStarLine();
            }
    
            }
        }
