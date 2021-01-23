    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            Dictionary<int, double> dictionary =
                new Dictionary<int, double>();
    
            dictionary.Add(100, 1.0);
            dictionary.Add(99, 1.1);
            //Add more item here
    
            // See whether Dictionary contains a value.
            if (dictionary.ContainsKey(100))
            {
                double value = dictionary[100];
                Console.WriteLine(String.Format("{0:0.0}",value));
            }
    
            Console.ReadLine();
        }
    }
