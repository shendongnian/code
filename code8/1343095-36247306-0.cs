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
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Id", typeof(int));
                dt1.Columns.Add("Name", typeof(string));
                dt1.Rows.Add(new object[] {1, "T1N1"});
                dt1.Rows.Add(new object[] {2, "T1N2"});
                dt1.Rows.Add(new object[] {3, "T1N3"});
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("Id", typeof(int));
                dt3.Columns.Add("Name", typeof(string));
                dt3.Rows.Add(new object[] {1, "T2N1"});
                dt3.Rows.Add(new object[] {2, "T2N2"});
                DataTable results = new DataTable();
                results.Columns.Add("Id", typeof(int));
                results.Columns.Add("T1_Id", typeof(int));
                results.Columns.Add("T2_Id", typeof(int));
                int id = 1;
                foreach (DataRow row3 in dt3.AsEnumerable())
                {
                    foreach (DataRow row1 in dt1.AsEnumerable())
                    {
                        results.Rows.Add(new object[] { id++, row3.Field<int>("Id"), row1.Field<int>("Id") });
                    }
                }
            }
        }
    }
