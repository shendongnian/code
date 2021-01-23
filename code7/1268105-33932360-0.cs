    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication58
    {
        class Program
        {
            static void Main(string[] args)
            {
                string connStr = "Enter Your Conneciton String Here";
                string SQL = "Select XML_COL_NAME from table1";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.WriteXml("filename");
            }
        }
    }
