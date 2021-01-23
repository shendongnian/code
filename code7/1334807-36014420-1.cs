    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            //Creating a list of lists that contains integers
            List<List<int>> clusters = new List<List<int>>();
            //each list in the above list consists of a list of integers. So we need to add list of integers to that list
            List<int> row = new List<int>();
            //now we add integers to the list
            row.Add(1); row.Add(2); row.Add(3); row.Add(4);
            //Now we add the list of integers to the list of lists of integers
            clusters.Add(row);
            
            foreach(List<int> rows in clusters)
            {
                foreach(int num in rows)
                {
                   System.Console.WriteLine(num);
                }
            }
            Console.WriteLine("number of rows: {0}", clusters.Count);
            Console.WriteLine("number of elements in the first row: {0}", clusters[0].Count);
        }
    }
