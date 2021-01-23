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
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("path", typeof(string));
                dt.Columns.Add("bow_ID", typeof(int));
                dt.Columns.Add("midfront_ID", typeof(int));
                dt.Columns.Add("midback_ID", typeof(int));
                dt.Columns.Add("stern_ID", typeof(int));
                dt.Rows.Add(new object[] {"gun1","guns\\guns_1", 0});
                dt.Rows.Add(new object[] {"gun2","guns\\guns_2", 0});
                dt.Rows.Add(new object[] {"gun3","guns\\guns_1", 0});
                dt.Rows.Add(new object[] {"gun4","guns\\guns_2", 0});
                List<DataRow> filter = dt.AsEnumerable()
                    .Where(x => x.Field<string>("path") == "guns\\guns_1" )
                    .ToList();
                //use dictionary
                Dictionary<string, List<DataRow>> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("path"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                List<DataRow> guns_1 = dict["guns\\guns_2"]; 
            }
        }
    }
    ​
 
