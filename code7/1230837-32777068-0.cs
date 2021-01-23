    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace LengthOfString
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "abcde\0\0\0";
                Console.WriteLine(s);
                Console.WriteLine();
                // Here I count the number of characters in s
                // using LINQ
                int counter = 0;
                s.ToList()
                    .ForEach(ch => {
                        Console.Write(string.Format("{0} ", (int)ch));
                        counter++;
                    });
                Console.WriteLine(); Console.WriteLine("LINQ: Length = " + counter);
                Console.WriteLine(); Console.WriteLine();
                //Or you could just use foreach for this
                counter = 0;
                foreach (int ch in s)
                {
                    Console.Write(string.Format("{0} ", (int)ch));
                    counter++;
                }
                Console.WriteLine(); Console.WriteLine("foreach: Length = " + counter);
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Press ENTER");
                Console.ReadKey();
            }
        }
    }
