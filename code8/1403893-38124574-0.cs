    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public class A
        {
            public int type;
            public string @params;
            public bool isActive;
        }
    
        public class B
        {
            public int type;
        }
        static void Main()
        {
            var aList = new List<A>
            {
                new A { type = 1, @params = "11", isActive = true },
                new A { type = 2, @params = "22", isActive = true },
                new A { type = 3, @params = "33", isActive = false },
            };
            var bList = new List<B>
            {
                new B { type = 2 },
                new B { type = 3 },
            };
            // create an index of the "type"s to look for
            var index = new HashSet<int>(bList.Select(x => x.type));
    
            // filter the primary list to values from the index
            var matches = aList.FindAll(x => index.Contains(x.type));
    
            foreach (var match in matches)
            {
                Console.WriteLine($"{match.type}, {match.@params}, {match.isActive}");
            }
        }
    }
