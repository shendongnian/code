    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    namespace ConsoleApplication21
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connStr = "Enter your connection string here";
                string SQL = "SELECT  StdId id, Name name FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                var student = dt.AsEnumerable()
                    .Select(x => new { id = x.Field<int>("id"), name = x.Field<string>("name") }).ToList();
            }
        }
    }
