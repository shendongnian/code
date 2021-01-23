    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\text.txt";
            static void Main(string[] args)
            {
                string connStr = "Enter Your connection string here";
                string SQL = "Enter your SQL here like Select * from table1";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                StreamWriter writer = new StreamWriter(FILENAME);
                foreach (DataRow row in dt.AsEnumerable())
                {
                    writer.WriteLine(string.Join("*", row.ItemArray));
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
    ​
