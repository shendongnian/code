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
                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Root><Engine></Engine><Engine></Engine><Engine></Engine></Root>";
     
                XDocument doc = XDocument.Parse(xml);
     
                foreach(XElement engine in doc.Descendants("Engine"))
                {
                    object[] newNode =  {
                        new object[] { new XElement("Host"), new XAttribute("name", "url")},
                        new object[] { new XElement("Value"), new XAttribute("className", "org.apache.catalina.valves.AccessLogValve")}
                    };
                    engine.Add(newNode);
                }
                
            }
        }
    }
