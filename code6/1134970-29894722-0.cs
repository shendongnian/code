    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    namespace ConsoleApplication20
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test1.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.CSV";
            static void Main(string[] args)
            {
                StreamWriter writer = new StreamWriter(OUTPUT_FILENAME);
                XmlDocument doc = new XmlDocument();
                doc.Load(INPUT_FILENAME);
                XmlNodeList reports =  doc.GetElementsByTagName("ExpenseReport");
                foreach (XmlNode report in reports)
                {
                    string my_UUID = report.SelectSingleNode("my_UUID").InnerText;
                    string status = report.SelectSingleNode("ExpenseReport_ReimbursementStatusCode").InnerText;
                    writer.WriteLine(string.Join(",", new string[] { my_UUID,status}));
                }
                writer.Flush();
                writer.Close();
                
            }
        }
    }
