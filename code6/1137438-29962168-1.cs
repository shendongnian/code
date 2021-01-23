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
                //get a dictionary the contains a double as a key and the value
                // the count of the number of times the key occurs
                Dictionary<double, int> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<double>("Total"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList().Count);
                //sample number of key to lookup
                double num = 778.660;
                //get the number of times the key appears in the input data.
                int count = dict[num];
            }
        }
    }
    ​
