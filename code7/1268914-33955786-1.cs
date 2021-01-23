    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using Newtonsoft.Json;
    
    namespace JSonConverter
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = "<Test><Name>Test class</Name><X>100</X><Y>200</Y></Test>";
    
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
    
                Console.WriteLine("XML -> JSON: {0}", json);
                Console.ReadLine();
                
            }
        }
    }
