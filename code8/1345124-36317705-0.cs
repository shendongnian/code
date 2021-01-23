    using System;
    using System.Data;
    using System.Data.Common;
    using Oracle.DataAccess.Client;
 
    class DataSourceEnumSample
    {
        static void Main()
        {
            string ProviderName = "Oracle.DataAccess.Client";
 
            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
 
            if (factory.CanCreateDataSourceEnumerator)
            {
                DbDataSourceEnumerator dsenum = factory.CreateDataSourceEnumerator();
                DataTable dt = dsenum.GetDataSources();
 
                // Print the first column/row entry in the DataTable
                Console.WriteLine(dt.Columns[0] + " : " + dt.Rows[0][0]);
                Console.WriteLine(dt.Columns[1] + " : " + dt.Rows[0][1]);
                Console.WriteLine(dt.Columns[2] + " : " + dt.Rows[0][2]);
                Console.WriteLine(dt.Columns[3] + " : " + dt.Rows[0][3]);
                Console.WriteLine(dt.Columns[4] + " : " + dt.Rows[0][4]);
            }
            else
                Console.Write("Data source enumeration is not supported by provider");
        }
    }
