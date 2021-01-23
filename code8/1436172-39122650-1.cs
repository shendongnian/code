    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("FromID", typeof(string));
                dt.Columns.Add("ToID", typeof(string));
                dt.Columns.Add("FromDate", typeof(DateTime));
                dt.Columns.Add("ToDate", typeof(DateTime));
                dt.Rows.Add(new object[] {"S1", "S2", DateTime.Parse("1/1/2016"), DateTime.Parse("1/15/2016")});
                dt.Rows.Add(new object[] {"S2", "S3", DateTime.Parse("2/1/2016"), DateTime.Parse("3/14/2016")});
                dt.Rows.Add(new object[] {"S1", "S2", DateTime.Parse("1/5/2016"), DateTime.Parse("1/20/2016")});
                dt.Rows.Add(new object[] {"S2", "S3", DateTime.Parse("1/25/2016"), DateTime.Parse("2/25/2016")});
                dt.Rows.Add(new object[] {"S1", "S2", DateTime.Parse("1/21/2016"), DateTime.Parse("1/25/2016")});
                dt = dt.AsEnumerable()
                    .OrderBy(x => x.Field<DateTime>("FromDate"))
                    .ThenBy(x => x.Field<string>("ToID"))
                    .ThenBy(x => x.Field<string>("ToID")).CopyToDataTable();
                for (int rowNum = dt.Rows.Count - 2; rowNum >= 0; rowNum--)
                {
                    if ((dt.Rows[rowNum]["FromID"] == dt.Rows[rowNum + 1]["FromID"]) &&
                        (dt.Rows[rowNum]["ToID"] == dt.Rows[rowNum + 1]["ToID"]))
                    {
                        dt.Rows[rowNum]["ToDate"] = dt.Rows[rowNum + 1]["ToDate"];
                        dt.Rows[rowNum + 1].Delete();
                    }
                }
                dt.AcceptChanges();
            }
        }
    }
