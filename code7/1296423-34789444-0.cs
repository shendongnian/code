    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication66
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Desc", typeof(string));
                dt.Columns.Add("Priority", typeof(string));
                dt.Rows.Add(new object[] {1, "aabc", "Priority1"});     
                dt.Rows.Add(new object[] {2, "xyz", "Priority3"});     
                dt.Rows.Add(new object[] {3, "cba", "Priority5"});     
                dt.Rows.Add(new object[] {4, "fg", "Priority2"});     
                dt.Rows.Add(new object[] {5, "xdr", "Priority4"});     
                dt.Rows.Add(new object[] {6, "pqr", "Priority1"});
                DataTable results = dt.AsEnumerable()
                    .OrderBy(x => x.Field<string>("Priority"))
                    .CopyToDataTable();
            }
        }
    }
