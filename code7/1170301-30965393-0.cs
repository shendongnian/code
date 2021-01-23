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
                DataTable query = new DataTable();
                query.Columns.Add("id", typeof(int));
                query.Columns.Add("name", typeof(string));
                query.Columns.Add("startDate", typeof(DateTime));
                query.Columns.Add("endDate", typeof(DateTime));
                query.Rows.Add(new object[] { 1, "John", DateTime.Parse("1/1/1 0:0:12"), DateTime.Parse("1/1/1 0:1:12") });
                query.Rows.Add(new object[] { 1, "John", DateTime.Parse("1/1/1 0:3:12"), DateTime.Parse("1/1/1 0:5:12") });
                query.Rows.Add(new object[] { 2, "Bob", DateTime.Parse("1/1/1 0:0:12"), DateTime.Parse("1/1/1 0:1:12") });
                query.Rows.Add(new object[] { 2, "Bob", DateTime.Parse("1/1/1 0:0:12"), DateTime.Parse("1/1/1 0:1:12") });
                var totalSeconds = query.AsEnumerable()
                    .Where(x => x.Field<int>("id") == 1)
                    .Select(x => (x.Field<DateTime>("endDate") - x.Field<DateTime>("startDate")).TotalSeconds).Sum();
            }
        }
    }
    ​
