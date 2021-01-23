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
                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Server><Service name=\"Catalina\">" +
                    "<Engine name=\"Catalina\"></Engine>" +
                    "<Engine name=\"Catalina\"></Engine>" +
                    "<Engine name=\"Catalina\"></Engine>" +
                    "</Service></Server>";
     
                XDocument doc = XDocument.Parse(xml);
     
                foreach(XElement engine in doc.Descendants("Engine"))
                {
                    object[] newNode =  { new XElement("Host", new XAttribute("name", "localhost")), new XElement("Value")};
                    engine.Add(newNode);
                }
                
            }
        }
    }
