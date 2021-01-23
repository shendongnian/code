    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace FahrentheitTest
    {
    class Program
    {
        static void Main(string[] args)
        {
            //conversion from Fahrenheit to Celsius
            Console.WriteLine("Input temperature value to view Fahrenheit to  Celsius: ");
            int fah = int.Parse(Console.ReadLine());
            Console.WriteLine();
    
            //conservsion formula from F to C
            int FtoC = ((fah - 32) * 5) / 9;
            Console.WriteLine("{0} Degrees Fahrenheit is {1} Celsius degrees. ", fah, FtoC);
            Console.WriteLine();
    
            //conversion from Celsius to fahrenheit
            Console.WriteLine("Input temperature value to view Celsius to Fahrenheit: ");
            int cel = int.Parse(Console.ReadLine());
            Console.WriteLine();
    
            //conversion formula from C to F
            int CtoF = ((cel * 9) /5) + 32;
            Console.WriteLine("{0} Degrees Celsius is {1} degrees Fahrenheit. " , cel, CtoF);
               Console.WriteLine();
           }
       }
    }
