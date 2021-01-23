    //example
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var dic = new Dictionary<string, Dictionary<string,HashSet<string>>>
            {
                {"k", new Dictionary<string,HashSet<string>>
                    {
                        {"k1", new HashSet<string>{"a","b","c"}}
                    }
                },
                {"k3", new Dictionary<string,HashSet<string>>
                    {
                        {"k4", new HashSet<string>{"1","2","3"}}
                    }
                }
            };
        
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
    output: k -- k1 -- a b c
            k3 -- k4 -- 1 2 3 
