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
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("DateString", typeof(string));
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-01"), "1 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-02"), "2 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-03"), "3 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-04"), "4 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-05"), "5 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-06"), "6 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-07"), "7 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-08"), "8 Jan 2015"});
                dt.Rows.Add(new object[] {DateTime.Parse("2015-01-09"), "9 Jan 2015"});
                dt.Rows.Add(new object[] { DateTime.Parse("2015-01-10"), "10 Jan 2015" });
                List<DateTime> findDates = new List<DateTime>() { DateTime.Parse("2015-01-01"), DateTime.Parse("2015-05-01"), DateTime.Parse("2015-10-01") };
                List<DataRow> unmatchRows = dt.AsEnumerable()
                    .Where(x => !findDates.Contains(x.Field<DateTime>("Date"))).ToList();
                foreach (DataRow row in unmatchRows)
                {
                    row["DateString"] = "";
                }
            }
        }
    }
    ​
