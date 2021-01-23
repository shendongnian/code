    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication41
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Limits> myList = new List<Limits>();
                //dictionary with unique keys
                Dictionary<string, Limits> dict1 = myList.AsEnumerable()
                    .GroupBy(x => x.col2, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //dictionary with keys having multiple values
                Dictionary<string, List<Limits>> dict2 = myList.AsEnumerable()
                    .GroupBy(x => x.col2, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                Limits abc = dict1["abc"];
            }
        }
        public class Limits
        {
            public String col1 { get; set; }
            public String col2 { get; set; }
            public String col3 { get; set; }
        }
    }
