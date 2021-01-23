    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace poleProstokata
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter value A");
                double a;
                if (Double.TryParse(Console.ReadLine(), out a)) {
                   a = Convert.ToDouble(Console.ReadLine());
                   
                   Console.WriteLine("Enter value B");
                   double b;
                   if (Double.TryParse(Console.ReadLine(), out b)) {
                      Console.WriteLine("Result value: "+ (a * b));
                      Console.Read();
                   } else {
                      Console.WriteLine("Invalid input for B!");
                   }
                } else {
                   Console.WriteLine("Invalid input for A!");
                }
            }
        }
    }
