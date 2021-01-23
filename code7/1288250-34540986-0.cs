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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Connection> connections = doc.Descendants("connection").Select(x => new Connection(){
                    Name = x.Attribute("name").Value,
                    IP = x.Element("ip").Value,
                    Port = int.Parse(x.Element("port").Value),
                    Description = x.Element("description").Value,
                }).ToList();
            }
        }
        public class Connection
        {
            public string Name { get; set; }
            public string IP { get; set; }
            public int Port { get; set; }
            public string Description { get; set; }
        }
    }
    ​
