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
                DataSet objDataSet = new DataSet();
                Dictionary<Int64, List<DataRow>> dict = objDataSet.Tables[0].AsEnumerable()
                    .GroupBy(x => x.Field<Int64>(0), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                
                foreach (var item in EU)
                {
                    List<DataRow> rows = dict[Convert.ToInt64(item.Substring(1, item.Length - 1))];
                }
            }
        }
    }
    ​
