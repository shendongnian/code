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
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("LastModified", typeof(DateTime));
                dt.Rows.Add(new object[] {1, "Raj", 38, DateTime.Parse("10/9/2015 2:26:28 PM")});
                dt.Rows.Add(new object[] {2, "Shiva", 27, DateTime.Parse("10/9/2015 10:36:53 PM")});
                dt.Rows.Add(new object[] {3, "John", 86, DateTime.Parse("10/5/2015 7:42:25 PM")});
                dt.Rows.Add(new object[] {4, "Lale", 56, DateTime.Parse("10/12/2015 3:36:26 PM")});
                DataRow lastest = dt.AsEnumerable().OrderByDescending(x => x.Field<DateTime>("LastModified")).FirstOrDefault();
            }
        }
    }
    ​
