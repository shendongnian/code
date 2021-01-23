    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                string name; 
                Console.WriteLine("Hi. Whats your name?");
                name = Console.ReadLine();
                Console.WriteLine("Hi {0} my name is John", name);
                Console.WriteLine("How old are you {0}?", name);
                string input = Console.ReadLine();
                int age;
                if (int.TryParse(input, out age)) {
                  if (age >= 35)
                  {
                    Console.WriteLine("You are getting old");
                  }
                  else // else if not needed
                  {
                    Console.WriteLine("You are still young");
                  }
                }
                else
                {
                    Console.WriteLine("Thats not an option!");
                }
            }
        }
    }
