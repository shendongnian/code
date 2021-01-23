    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                string input =
                    "<XML><DSTATUS>1,4,7,,5</DSTATUS><EVENT> hello,there,my,name,is,jack,</EVENT>" +
                       "last,name,missing,above <ANOTHERTAG>3,6,7,,8,4</ANOTHERTAG> </XML>" +
                    "<XML><DSTATUS>1,5,7,,3</DSTATUS><EVENT>hello,there,my,name,is,mary,jane</EVENT>" +
                       "last,name,not,missing,above<ANOTHERTAG>3,6,7,,8,4</ANOTHERTAG></XML>";
                input = "<Root>" + input + "</Root>";
                XmlDocument  doc = new XmlDocument();
                doc.LoadXml(input);
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlNodeList rows = doc.GetElementsByTagName("XML");
                foreach (XmlNode row in rows)
                {
                    List<string> children = new List<string>();
                    foreach (XmlNode child in row.ChildNodes)
                    {
                        children.Add(child.InnerText.Trim());
                    }
                    
                    writer.WriteLine(string.Join(",", children.ToArray()));
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
    ​
