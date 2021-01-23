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
                dt.Columns.Add("Col A", typeof(int));
                dt.Columns.Add("Col B", typeof(int));
                dt.Columns.Add("Col C", typeof(int));
                dt.Rows.Add(new object[] { 1, 2, 3});
                dt.Rows.Add(new object[] { 10, 20, 30 });
                dt.Rows.Add(new object[] { 100, 200, 300 });
                List<DataRow> rows = dt.AsEnumerable().Select(x => x).ToList();
                var numbers = dt.AsEnumerable().Select(x => x.ItemArray).ToList();
      
            }
        }
    }
    ​
    ​
