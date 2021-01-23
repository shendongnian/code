    using System;
    using System.Collections;
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
                dt.Columns.Add("Col1", typeof(string));
                dt.Columns.Add("Col2", typeof(string));
                dt.Columns.Add("Col3", typeof(string));
                dt.Rows.Add(new object[] {"AAA","BBB","DEF"});
                dt.Rows.Add(new object[] {"AAA","BBB","QEW"});
                dt.Rows.Add(new object[] {"RRR","WWW","123"});
                dt.Rows.Add(new object[] {"RRR","WWW","321"});
                dt.Rows.Add(new object[] {"XXX","WWW","421"});
                var results = dt.AsEnumerable()
                    .GroupBy(x => new  {col1 =  x.Field<string>("Col1"), col2 = x.Field<string>("Col2") })
                    .Select(x => new { 
                        col1 = x.FirstOrDefault().Field<string>("Col1"),
                        col2 = x.FirstOrDefault().Field<string>("Col2"),
                        col3 = string.Join("",x.Select(y => y.Field<string>("Col3")).ToArray())
                    })
                    .ToList();
            }
        }
    }
    ​
