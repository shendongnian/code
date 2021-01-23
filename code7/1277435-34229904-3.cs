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
                writer.WriteStartElement("entry");
                double?[] attributes = new double?[] { null, 91.3467, 95.3052, 6.4722 };
                int index = 1;
                foreach (double? attribute in attributes)
                {
                    writer.WriteStartAttribute("Attrib" + index++.ToString());
                    if (attribute == null)
                    {
                        writer.WriteValue("");
                    }
                    else
                    {
                        writer.WriteValue(attribute);
                    } 
                    writer.WriteEndAttribute();
                }
                writer.WriteEndElement();
                writer.WriteStartElement("entry");
                attributes = new double?[] { null, 91.3467, 95.3052, 6.4722 };
                index = 1;
                foreach (double? attribute in attributes)
                {
                    writer.WriteStartAttribute("Attrib" + index++.ToString());
                    if (attribute == null)
                    {
                        writer.WriteValue("");
                    }
                    else
                    {
                        writer.WriteValue(attribute);
                    }
                    writer.WriteEndAttribute();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
    ​
