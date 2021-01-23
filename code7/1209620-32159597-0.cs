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
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                int count = 0;
                foreach (DataRow row in dt.AsEnumerable())
                {
                    Console.WriteLine("Row {0} : {1}", count++, string.Join(",", row.ItemArray));
                }
               
            }
        }
    }​
