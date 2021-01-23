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
            Console.Write("Number: ");
            string inputStr = Console.ReadLine();
            int[] array = new int[30];
            int i = 0;
            foreach(Char c in inputStr)
            {
                array[i] = Convert.ToInt32(c.ToString());
                i++;
            }
            Console.WriteLine("");
            foreach (int num in array)
            {
                Console.WriteLine(num.ToString());
            }
            Console.ReadLine();
        }
      }
    }
