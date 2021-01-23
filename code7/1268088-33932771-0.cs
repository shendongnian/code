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
                string SQL = "INSERT INTO Table1 (Time_Col) VALUES ('@MyTime');";
                
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.Add("@MyTime", SqlDbType.DateTime);
                DateTime now = DateTime.Now();
                cmd.Parameters["@MyTime"].Value = now;
                cmd.EndExecuteNonQuery();
            }
        }
    }
