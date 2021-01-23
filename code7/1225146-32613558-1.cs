    using System;
    
    namespace testCS
    {
        class Program
        {
            static void Main(string[] args)
            {
                string name = "Bob";
                string age = "";
    
                Console.Write("What is your name? ");
                name = Console.ReadLine();
                Console.WriteLine("Hello, " + name);
    
                Console.Write("How old are you? ");
                age = Console.ReadLine();
                Console.WriteLine(name + ", age " + age);
    
                Console.ReadLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
