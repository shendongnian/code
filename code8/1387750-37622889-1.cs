    using System;
    
    namespace ReflectionAndIndexers
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ri = new ReflectionIndexer();
                ri["StrProp1"] = "test1";
                ri["StrProp2"] = "test2";
                ri["IntProp1"] = 1;
                ri["IntProp2"] = 2;
    
                Console.WriteLine(ri.StrProp1);
                Console.WriteLine(ri.StrProp2);
                Console.WriteLine(ri.IntProp1);
                Console.WriteLine(ri.IntProp2);
                Console.ReadLine();
            }
        }
    }
