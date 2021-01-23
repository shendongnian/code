    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME1 = @"c:\temp\test.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                DataSet ds1 = new DataSet();
                ds1.ReadXml(FILENAME1);
                DataSet ds2 = new DataSet();
                ds2.ReadXml(FILENAME2);
                var results = from dataRows1 in ds1.Tables["member"].AsEnumerable()
                                         join dataRows2 in ds2.Tables["member"].AsEnumerable()
                                         on dataRows1.Field<string>("id") equals dataRows2.Field<string>("id") into ps
                                         select dataRows1;
                DataTable combinedTable = results.CopyToDataTable();
                
            }
        }
    }​
