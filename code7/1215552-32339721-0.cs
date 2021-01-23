    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication45
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connStr = "Enter Your connection strin gHere";
                string SQL = "Enter your SQL Here";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string firm  = "abc";
                List<DataRow> clientData = dt.AsEnumerable().Where(x => x.Field<string>("firm") == firm).ToList();
     
            }
        }
      
    }
