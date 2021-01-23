    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        using StrStrDict = Dictionary<string, string>;
        public sealed class CustomComparer: IComparer<StrStrDict>
        {
            public int Compare(StrStrDict lhs, StrStrDict rhs)
            {
                double x = Double.Parse(lhs["number"]);
                double y = Double.Parse(rhs["number"]);
                return x.CompareTo(y);
            }
        }
        internal class Program
        {
            private static void Main()
            {
                var dict1 = new StrStrDict
                {
                    {"name",   "name1"},
                    {"number", "0.0158"}
                };
                var dict2 = new StrStrDict
                {
                    {"name",   "name2"},
                    {"number", "0.0038"}
                };
                var dict3 = new StrStrDict
                {
                    {"name",   "name3"},
                    {"number", "0.0148"}
                };
                var list = new List<StrStrDict> {dict1, dict2, dict3};
                list.Sort(new CustomComparer());
                foreach (var element in list)
                {
                    Console.WriteLine("Number = " + element["number"]);
                }
            }
        }
    }
