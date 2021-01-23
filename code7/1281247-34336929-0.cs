    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Reversebinary
    {
        class Reversebinary
        {
            static byte[] reverseBinary = new byte[] {0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };  
            static void Main(string[] args)
            {
                //Convert Decimal to binary
                int num;
                int reversed;
                //Read integer value from console
                num = int.Parse(Console.ReadLine());
                if (num >= 0 && num <= 15)
                {
                    //reverse string binary
                    reversed = reverseBinary[num];
                    Console.WriteLine(reversed.ToString("x2"));
                }
                else
                    Console.WriteLine("Number is not between 0 and 15");
            }
        }
    }
    ​
