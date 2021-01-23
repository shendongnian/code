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
                Dictionary<string, List<string>> two_Dict = new Dictionary<string, List<string>>();
                var keyIndex = two_Dict.Keys.AsEnumerable()
                    .Select((x, i) => new { index = i, value = x })
                    .ToList();
                var result = (from key1 in keyIndex
                              from key2 in keyIndex
                              where key1.index > key2.index 
                              where AreEqual(two_Dict[key1.value],two_Dict[key2.value])
                              select new {key1 = key1.value, key2 = key2.value}).ToList(); 
            }
            static bool AreEqual<T>(List<T> x, List<T> y)
            {
                // same list or both are null
                if (x == y)
                {
                    return true;
                }
                // one is null (but not the other)
                if (x == null || y == null)
                {
                    return false;
                }
                // count differs; they are not equal
                if (x.Count != y.Count)
                {
                    return false;
                }
                x.Sort();
                y.Sort();
                for (int i = 0; i < x.Count; i++)
                {
                    if (!x[i].Equals(y[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
    ​
