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
            const string FILENAME = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                string connstr = "Enter your connection string here";
                string SQL = "Enter your SQL Here";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connstr);
                SqlCommand cmd = adapter.SelectCommand;
                cmd.Parameters.Add("abc", SqlDbType.VarChar);
                adapter.SelectCommand.ExecuteNonQuery();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
            }
        }
    }
