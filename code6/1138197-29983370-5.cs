    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        using StrObjDict = Dictionary<string, object>;
        public sealed class CustomComparer: IComparer<StrObjDict>
        {
            public int Compare(StrObjDict lhs, StrObjDict rhs)
            {
                double x = (double)lhs["number"];
                double y = (double)rhs["number"];
                return x.CompareTo(y);
            }
        }
        internal class Program
        {
            private static void Main()
            {
                var dict1 = new StrObjDict
                {
                    {"name",   "name1"},
                    {"number", 0.0158}
                };
                var dict2 = new StrObjDict
                {
                    {"name",   "name2"},
                    {"number", 0.0038}
                };
                var dict3 = new StrObjDict
                {
                    {"name",   "name3"},
                    {"number", 0.0148}
                };
                var list = new List<StrObjDict> {dict1, dict2, dict3};
                list.Sort(new CustomComparer());
                foreach (var element in list)
                {
                    Console.WriteLine("Name = {0}, Number = {1}", element["name"], element["number"]);
                }
            }
        }
    }
