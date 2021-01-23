    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication91
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = 
                "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<IndexRoot Code=\"0664\" xmlns=\"http://tempuri/2012/1.0\">" +
                   "<Name>Foo</Name>" +
                   "<Color>blue</Color>" +
               "</IndexRoot>";
                XDocument doc = XDocument.Parse(xml);
                XElement indexRoot = (XElement)doc.FirstNode;
                XNamespace ns = indexRoot.Name.Namespace;
                string name = indexRoot.Element(ns + "Name").Value;
                XElement indexRoot2 = doc.Descendants().Where(x => x.Name.LocalName == "IndexRoot").FirstOrDefault();
                
            }
        }
       
    }
