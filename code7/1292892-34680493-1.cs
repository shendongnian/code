    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main() {} // Just to make it simpler to compile
    
        public static void ForEach(List<int> x)
        {        
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
        }
        
        public static void While(List<int> x)
        {
            using (var enumerator = x.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }
    }
