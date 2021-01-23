    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ReturnColumnName colName = new ReturnColumnName();
                    string input = "<?xml version=\"1.0\"?><open></open>";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(input);
                    XmlElement opener = (XmlElement)doc.GetElementsByTagName("open")[0];
                    XmlElement dataNode = doc.CreateElement("dataex");
                    XmlElement child = (XmlElement)colName.GenerateColumnsForTable("code", doc, dataNode);
                    if (opener.ChildNodes.Count == 0)
                    {
                        opener.AppendChild(child);
                    }
                    else
                    {
                        opener.PrependChild(child);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The error is :" + ex);
                    Console.ReadKey();
                }
            }
            public class ReturnColumnName
            {
                public XmlNode GenerateColumnsForTable(string tableName, XmlDocument doc, XmlNode dataNode)
                {
                    //Here i am using the same doc and dataNode to create xml
                    return dataNode;
                }
            }
        }
    }
    ​
