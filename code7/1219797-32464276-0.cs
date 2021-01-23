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
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("content", typeof(string));
                dt.Columns.Add("type", typeof(string));
                dt.Columns["type"].AllowDBNull = true;
                dt.Columns.Add("date", typeof(DateTime));
                dt.Rows.Add(new object[] { 0, "Some text", "TypeA", DateTime.Parse("2013-04-01")});
                dt.Rows.Add(new object[] { 1, "Some older text", "TypeA", DateTime.Parse("2012-03-01")});
                dt.Rows.Add(new object[] { 2, "Some older texttext", "TypeA", DateTime.Parse("2011-01-01")});
                dt.Rows.Add(new object[] { 3, "Sample", null, DateTime.Parse("2013-02-24")});
                dt.Rows.Add(new object[] { 3, "A dog", "TypeB", DateTime.Parse("2013-04-01")});
                dt.Rows.Add(new object[] { 4, "And older dog", "TypeB", DateTime.Parse("2012-03-01")});
                dt.Rows.Add(new object[] { 5, "An even older dog", "TypeB", DateTime.Parse("2011-01-01")});
                dt.Rows.Add(new object[] { 4, "Another sample", null, DateTime.Parse("2014-03-06")});
                dt.Rows.Add(new object[] { 5, "Test", null, DateTime.Parse("2015-11-08")});
                var results = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("type"))
                    .Select(x => x.Key == null ? x.ToList() : x.Select(y => new {date = y.Field<DateTime>("date"), row = y}).OrderByDescending(z => z.date).Select(a => a.row).Take(1))
                    .SelectMany(b => b).Select(c => new {
                        content = c.Field<string>("content"), 
                        type = c.Field<string>("type") 
                    }).ToList();
            }
        }
    }
    ​
