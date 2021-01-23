    using System;
    using System.Collections.Generic;
    namespace BinarySearchmethod
    {
        class AKSHAY
        {
            static void Main(string[] args)
            {
                List<string> list = new List<string>() { "A", "B", "C", "D", "E", "F", "G" };
                int index1 = list.BinarySearch("C");
                Console.WriteLine("Index 1: {0}", index1);
                int index2 = list.BinarySearch("F");
                Console.WriteLine("Index 2 : {0} ", index2);
                int index3 = list.BinarySearch("H");
                Console.WriteLine("Index 3 : {0} ", index3); 
                // wait for input before exiting
                Console.WriteLine("Press enter to finish");
                Console.ReadLine();
            }
        }
    }
