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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string SQL = "Enter Your SQL Select string here";
                string connStr = "Enter You connection string here";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ds.DataSetName = "SALES_ORDERS";
                ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
            }
        }
    }
    ​
