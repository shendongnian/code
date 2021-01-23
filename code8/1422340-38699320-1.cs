    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Product_ID", typeof(int));
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Price", typeof(int));
                dt.Rows.Add(new object[] {1, DateTime.Parse("2001-01-01"),  10});  
                dt.Rows.Add(new object[] {1, DateTime.Parse("2001-02-01"),  10});  
                dt.Rows.Add(new object[] {1, DateTime.Parse("2001-03-01"),  15});  
                dt.Rows.Add(new object[] {1, DateTime.Parse("2001-04-01"),  10});  
                dt.Rows.Add(new object[] {1, DateTime.Parse("2001-05-01"),  20});  
                dt.Rows.Add(new object[] {1, DateTime.Parse("2001-06-01"),  20});
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2001-01-01"), 10 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2001-02-01"), 10 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2001-03-01"), 15 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2001-04-01"), 10 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2001-05-01"), 20 });
                dt.Rows.Add(new object[] { 2, DateTime.Parse("2001-06-01"), 20 });  
                dt = dt.AsEnumerable().OrderBy(x => x.Field<DateTime>("Date")).CopyToDataTable();
                List<DataRow> results = dt.AsEnumerable()
                    .GroupBy(g => g.Field<int>("Product_ID"))
                    .Select(g1 => g1.Select((x, i) => new { row = x, dup = (i == 0) || ((i > 0) && (g1.Skip(i - 1).FirstOrDefault().Field<int>("Price") != g1.Skip(i).FirstOrDefault().Field<int>("Price"))) ? false : true })
                    .Where(y => y.dup == false).Select(z => z.row)).SelectMany(m => m).ToList();
                    
            }
        }
    }
