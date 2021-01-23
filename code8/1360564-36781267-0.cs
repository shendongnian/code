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
                Dictionary<string, Computer> dict = new Dictionary<string, Computer>();
                string xml =
                        "<Computers>" +
                          "<PrimaryServers>" +
                            "<Location1 type=\"primary\">" +
                              "<Ipaddress>192.168.1.2</Ipaddress>" +
                              "<IsAlive>true</IsAlive>" +
                            "</Location1>" +
                            "<Location2></Location2>" +
                          "</PrimaryServers>" +
                          "<SecondaryServers>" +
                            "<Location1 type=\"secondary\">" +
                              "<Ipaddress>192.168.1.3</Ipaddress>etc..." +
                            "</Location1>" +
                          "</SecondaryServers>" +
                          "<Clients>" +
                            "<Location1 type=\"secondary\">" +
                              "<Ipaddress>192.168.1.4</Ipaddress>etc..." +
                            "</Location1>" +
                          "</Clients>" +
                        "</Computers>";
                XDocument doc = XDocument.Parse(xml);
                List<XElement> computers = doc.Descendants("Computers").Elements().ToList();
                foreach (XElement computer in computers)
                {
                    dict.Add((string)computer.Descendants("Ipaddress").FirstOrDefault(), new Computer()
                    {
                        ip = (string)computer.Descendants("Ipaddress").FirstOrDefault(),
                        type = (string)computer.Descendants("Location1").FirstOrDefault().Attribute("type")
                    });
                }
            }
        }
        public class Computer
        {
            public string ip { get; set; }
            public string location1 { get; set; }
            public string location2 { get; set; }
            public string type { get; set; }
        }
    }
