    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = "<?xml version=\"1.0\" ?><root><data></data></root>";
                XDocument doc = XDocument.Parse(xml);
                XElement data = doc.Descendants("data").FirstOrDefault();
                double?[] attributes = new double?[] { null, 91.3467, 95.3052, 6.4722};
     
                XElement entry = new XElement("entry");
                data.Add(entry);
                int index = 1;
                foreach(double? attribute in attributes)
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
                attributes = new double?[] { null, 91.3467, 95.3052, 6.4722 };
                entry = new XElement("entry");
                data.Add(entry);
                index = 1;
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
            }
        }
    }
    ​
