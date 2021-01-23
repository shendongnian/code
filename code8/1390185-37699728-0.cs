    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication99
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ID", typeof(int));
                dt1.Columns.Add("COLOR", typeof(string));
                dt1.Columns.Add("NAME", typeof(string));
                dt1.Rows.Add(new object[] { 1, "red", "aaa"});
                dt1.Rows.Add(new object[] { 2, "red", "vvv"});
                dt1.Rows.Add(new object[] { 3, "green", "fff"});
                dt1.Rows.Add(new object[] { 4, "green", "ggg"});
                dt1.Rows.Add(new object[] { 5, "yellow", "eee"});
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("COLOR", typeof(string));
                dt2.Columns.Add("COUNT", typeof(int));
                var groups = dt1.AsEnumerable().GroupBy(x => x.Field<string>("COLOR"));
                foreach(var group in groups)
                {
                    dt2.Rows.Add(new object[] {group.Key, group.Count()});
                }
            }
        }
    }
