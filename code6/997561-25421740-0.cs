    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        internal static class Program
        {
            static void Main()
            {
                var myList = new List<string>
                {
                    "1A",
                    "1B",
                    "2A",
                    "3C",
                    "4D"
                };
                var newList = myList.Distinct(new MyComparer());
                Console.WriteLine(string.Join("\n", newList));
            }
            sealed class MyComparer: IEqualityComparer<string>
            {
                public bool Equals(string x, string y)
                {
                    if (x.Length != y.Length)
                        return false;
                    if (x.Length == 0)
                        return true;
                    return (string.Compare(x, 1, y, 1, x.Length) == 0);
                }
                public int GetHashCode(string s)
                {
                    if (s.Length <= 1)
                        return 0;
                    int result = 17;
                    unchecked
                    {
                        bool first = true;
                    
                        foreach (char c in s)
                        {
                            if (first)
                                first = false;
                            else
                                result = result*23 + c;
                        }
                    }
                    return result;
                }
            }
        }
    }
