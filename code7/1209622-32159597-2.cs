    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connStr = "Enter your conneciton string here";
                string SQL = "Enter your SQL here";
                //uncomment lines below
                //SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                //DataTable dt = new DataTable();
                //adapter.Fill(dt);
                //simulated table
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("City", typeof(string));
                dt.Rows.Add(new object[] { "John", 22, "NY" });
                dt.Rows.Add(new object[] { "Mary", 27, "Boston" });
                dt.Rows.Add(new object[] { "Paul", 18, "Chicago" });
                int count = 0;
                foreach (DataRow row in dt.AsEnumerable())
                {
                    Console.WriteLine("Row {0} : {1}", (count++).ToString(), string.Join(",", row.ItemArray.Select(x => x.ToString()).ToArray()));
                }
                Console.ReadLine();
            }
        }
    }
