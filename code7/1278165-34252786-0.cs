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
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Logdate", typeof(DateTime));
                dt.Columns.Add("Sale", typeof(decimal));
                dt.Rows.Add(new object[] { "Test", DateTime.Parse("12/03/2015"), 4.5 });
                dt.Rows.Add(new object[] { "Test", DateTime.Parse("12/13/2015"), 15 });
                dt.Rows.Add(new object[] { "Test2", DateTime.Parse("12/18/2015"), 3 });
                dt.Rows.Add(new object[] { "Test2", DateTime.Parse("12/25/2015"), 40 });
                Dictionary<string, List<DataRow>> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("UserName"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                foreach (string key in dict.Keys)
                {
                    List<int> days = dict[key].Select(x => x.Field<DateTime>("Logdate").Day).OrderBy(x => x).ToList();
                    int month = dict[key].Select(x => x.Field<DateTime>("Logdate").Month).FirstOrDefault();
                    int year = dict[key].Select(x => x.Field<DateTime>("Logdate").Year).FirstOrDefault();
                    int lastDay = (new DateTime(year, month, 1)).AddMonths(1).AddDays(-1).Day;
                    for (int day = 1; day <= lastDay; day++)
                    {
                        if(!days.Contains(day))
                        {
                           dt.Rows.Add(new object[] { key, new DateTime(year, month, day), 0 });
                        }
                    }
                }
     
            }
        }
    }
    ​
