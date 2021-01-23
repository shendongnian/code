    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                Dictionary<double, int> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<double>("Total"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList().Count);
                double num = 778.660;
                int count = dict[num];
            }
        }
    }
    ​
