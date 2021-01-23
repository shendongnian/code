    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace FruitShop
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Type a fruit name:");
                var fruit = Console.ReadLine();
                
                Console.WriteLine("Type a week's day:");
                var weekday = Console.ReadLine();
                
                Console.WriteLine("Type a quantity:");
                var quantuty = double.Parse(Console.ReadLine());
    
                if (fruit == "banana")
                {
                    if (weekday != "saturday" && weekday != "sunday")
                        Console.WriteLine(quantuty * 2.50);
    
                     if (weekday == "saturday")
                    {
                        Console.WriteLine(quantuty * 2.70);
                    }
                     if (weekday == "sunday")
                    {
                        Console.WriteLine(quantuty * 2.70);
                    }
                }
                //Here. All the if's should be inside this main else-if
                else if (fruit == "apple")
                {
                    if (weekday != "saturday" && weekday != "sunday")
                    {
                        Console.WriteLine(quantuty * 1.20);
                    }
               
                     if (weekday == "saturday")
                     {
                        Console.WriteLine(quantuty * 1.25);
                     }
                     if (weekday == "sunday")
                     {
                        Console.WriteLine(quantuty * 1.25);
                     }
                }
    
    
            }
        }
    } 
