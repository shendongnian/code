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
                List<myObj> objs = new List<myObj>();
                Dictionary<string, int> dict = objs.AsEnumerable()
                    .GroupBy(x => x.type, y => y)
                    .ToDictionary(x => x.Key, y => y.Select(z => z.amount).Sum());
            }
        }
        public class myObj
        {
            public string type { get; set; }
            public int amount { get; set; }
        }
    }
