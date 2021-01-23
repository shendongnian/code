    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Exer_13
    {
        class Program
        {
            static void Main(string[] args)
            {
            /* ------------------------------------------ */
           DateTime dt = DateTime.Now;
            String name = "";
            DateTime birthDate;
            DateTime futureDay;
            int age;
            /* ------------------------------------------ */
            Console.WriteLine("Current Date Is: " + dt);
            Console.WriteLine("\n\r");
            Console.Write("Please Enter Your Name: ");
            name = Console.ReadLine();
            Console.WriteLine("\n\r");
            Console.Write("Enter your birthday: ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                //Console.WriteLine("You will be 100 Years old At this Date: {0}", birthDate);
                Console.WriteLine("\n\r");
            }
            else
            {
                Console.WriteLine("You have entered an invalid year." + Environment.NewLine);
                Console.WriteLine("\n\r");
            }
            Console.Write("Enter age: ");
            if (int.TryParse(Console.ReadLine(), out age))
            {
                //TimeSpan age = DateTime.Now - birthDate;
                futureDay = birthDate.AddYears(age);
                Console.WriteLine("You will be 100 Years old At this Date: {0}", futureDay.ToString("dd MMM yyyy"));
                Console.WriteLine("\n\r");
            }
            else
            {
                Console.WriteLine("You have entered an invalid year." + Environment.NewLine);
                Console.WriteLine("\n\r");
            }
            /*
               Code goes here
            */
            Console.ReadKey();
            }
        }
    }
