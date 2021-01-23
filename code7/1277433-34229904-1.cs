    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamWriter sWriter = new StreamWriter(FILENAME);
                XmlTextWriter writer = new XmlTextWriter(sWriter);
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteStartElement("data");
                double?[] attributes = new double?[] { null, 91.3467, 95.3052, 6.4722 };
                XElement entry = new XElement("entry");
                int index = 1;
                foreach (double? attribute in attributes)
                {
                    if (attribute == null)
                    {
                        entry.Add(new XAttribute("Attrib" + index++.ToString(), ""));
                    }
                    else
                    {
                        entry.Add(new XAttribute("Attrib" + index++.ToString(), attribute));
                    }
                }
                writer.WriteRaw(entry.ToString());
                writer.WriteRaw(entry.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
    ​
