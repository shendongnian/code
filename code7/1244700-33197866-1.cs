    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Headache", typeof(string));
                dt.Columns.Add("Nausea", typeof(string));
                dt.Columns.Add("Temp", typeof(string));
                dt.Columns.Add("Flu", typeof(string));
                dt.Rows.Add(new string[] {"no", "no" ,"normal", "no"});
                dt.Rows.Add(new string[] {"yes", "no" ,"high", "yes"});
                dt.Rows.Add(new string[] {"yes", "yes" ,"high", "yes"});
                dt.Rows.Add(new string[] {"yes", "no" ,"normal", "no"});
                dt.Rows.Add(new string[] {"no", "no" ,"high", "no"});
                dt.Rows.Add(new string[] {"no", "no" ,"high", "yes"});
                var dict = dt.AsEnumerable()
                    .GroupBy(x => new { Headache = x.Field<string>("Headache"), Nausea = x.Field<string>("Nausea"), Temp = x.Field<string>("Temp") }, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                DataTable dt2 = dict.Where(x => x.Value.Count == 1).SelectMany(y => y.Value).CopyToDataTable();
                //or simply this
                DataTable dt3 = dt.AsEnumerable()
                    .GroupBy(x => new { Headache = x.Field<string>("Headache"), Nausea = x.Field<string>("Nausea"), Temp = x.Field<string>("Temp") })
                    .Where(x => x.Count() == 1).SelectMany(y => y).CopyToDataTable();
            }
        }
    }
    ​
