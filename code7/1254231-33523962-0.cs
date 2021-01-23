    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Test
    {
        public static void Main()
        {
            List<String> inner = new List<string>() { "i1", "i2" };
            List<String> outer = new List<string>() { "o1", "o2" };
    
            outer.GroupJoin(inner, i => i, o=> o,
                (inKey, outCollection) => new {Key = inKey, List = outCollection},
                new CustomEqualityComparer<string>((i, o) => i == o)).ToList();
        }
    }
    
    public class CustomEqualityComparer<T> : IEqualityComparer<T>
    {
        public CustomEqualityComparer(Func<T, T, bool> cmp)
        {
            this.cmp = cmp;
        }
        public bool Equals(T x, T y)
        {
            Console.WriteLine("Comparing {0} and {1}", x, y);
            return cmp(x, y);
        }
    
        public int GetHashCode(T obj)
        {
            // Always return 0 so that the function is called
            return 0;
        }
    
        public Func<T, T, bool> cmp { get; set; }
    }
