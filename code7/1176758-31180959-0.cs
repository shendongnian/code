    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("MyTable");
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Id", typeof(int));
                dt.Rows.Add(new object[] { "John", 1});
                dt.Rows.Add(new object[] { "Mary", 2});
                dt.Rows.Add(new object[] { "Dick", 3});
                dt.Rows.Add(new object[] { "Harry", 4});
                dt.Rows.Add(new object[] { "Jane", 5});
                DataSet ds = new DataSet("MySet");
                ds.Tables.Add(dt);
                ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
                // or
                //ds.WriteXml(FILENAME);
     
            }
            
        }
     
    }
