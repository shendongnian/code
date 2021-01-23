    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication82
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<OrderDateSummary> orderSummary = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("date", typeof(DateTime));
                dt.Columns.Add("amount", typeof(decimal));
                dt.Rows.Add(new object[] { 1, DateTime.Parse("1/1/16"), 1.00 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("1/1/16"), 2.00 });
                dt.Rows.Add(new object[] { 3, DateTime.Parse("1/2/16"), 3.00 });
                dt.Rows.Add(new object[] { 4, DateTime.Parse("1/2/16"), 4.00 });
                dt.Rows.Add(new object[] { 5, DateTime.Parse("1/2/16"), 5.00 });
                dt.Rows.Add(new object[] { 6, DateTime.Parse("1/3/16"), 6.00 });
                dt.Rows.Add(new object[] { 7, DateTime.Parse("1/3/16"), 7.00 });
                orderSummary = dt.AsEnumerable()
                    .GroupBy(x => x.Field<DateTime>("date"))
                    .Select(x => new OrderDateSummary() { Date = x.Key, Total = x.Count() })
                    .ToList();
            }
         
        }
        public class OrderDateSummary {
          public DateTime Date { get; set; }
          public int Total { get; set; }
        }
    }
