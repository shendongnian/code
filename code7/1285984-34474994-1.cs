    //example
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var dic = new Dictionary<string, Dictionary<string,HashSet<string>>>();
        
            foreach(var p in dic)
            {
                Console.Write(p.Key + " -- ");
                foreach(var p1 in p.Value)
                {
                    Console.Write(p1.Key + " -- ");
                    foreach(var str in p1.Value)
                    {
                        Console.Write(str + " ");
                    }
                }
                Console.WriteLine();
            }
        } 
    }
 
