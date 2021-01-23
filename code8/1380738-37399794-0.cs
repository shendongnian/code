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
                var results = doc.Descendants("Policy").Select(x => new {
                    number = (int)x.Attribute("Number"),
                    name = (string)x.Element("PolicyName"),
                    performSnapshot = (string)x.Descendants("PerformSnapshot").FirstOrDefault(),
                    dataClassification = (string)x.Descendants("DataClassification").FirstOrDefault(),
                    clients = x.Descendants("Client").Select(y => new {
                        number = (int)y.Attribute("Number"),
                        clientHostname = (string)y.Element("ClientHostname"),
                        clientHardware = (string)y.Element("ClientHardware"),
                        clientOS = (string)y.Element("ClientOS"),
                        clientPriority = (int)y.Element("ClientPriority"),
                    }).ToList(),
                    schedule = x.Descendants("Schedule").Select(y => new {
                        number = (int)y.Attribute("Number"),
                        scheduleName = (string)y.Element("ScheduleName"),
                        residenceIsSLP = (string)y.Element("ResidenceIsSLP")
                    }).ToList()
                }).ToList();
            }
        }
    }
