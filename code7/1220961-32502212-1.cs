    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("UnknownTable");
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("ticket-id", typeof(int));
                dt.Rows.Add(new object[] { 11528, 4917 });
                dt.Rows.Add(new object[] { 11529, 4918 });
                string identification =
                    "<?xml version=\"1.0\" encoding=\"utf8\"?>" +
                    "<table name=\"UnknownTable\">" +
                    "</table>";
                XDocument doc = XDocument.Parse(identification);
                XElement table = doc.Root;
                foreach (DataRow row in dt.AsEnumerable())
                {
                    XElement newRow = new XElement("row");
                    table.Add(newRow);
                    for (int colNum = 0; colNum < dt.Columns.Count; colNum++)
                    {
                        string name = dt.Columns[colNum].ColumnName;
                        newRow.Add(new XElement(name, row[colNum]));
                    }
                }
            }
        }
    }
    ​
