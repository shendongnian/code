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
                string xml =
                   "<Feed>" +
                      "<Control>" +
                        "<UserName>testUser</UserName>" +
                        "<Password>testPass</Password>" +
                      "</Control>" +
                      "<leeds>" +
                        "<leed>" +
                          "<leedid>4990935</leedid>" +
                          "<Reference>4990935</Reference>" +
                          "<IncidentDetails>" +
                            "<IncidentDate>2015-08-05</IncidentDate>" +
                            "<AccidentDetails>damage</AccidentDetails>" +
                          "</IncidentDetails>>" +
                            "<ClientDetails>" +
                              "<ClientsID>4990935</ClientsID>" +
                              "<ClientsName>Test Name</ClientsName>" +
                            "</ClientDetails>" +
                            "<IncidentDetails>" +
                              "<IncidentID>557475</IncidentID>" +
                              "<IncidentName>Injury</IncidentName>" +
                            "</IncidentDetails>" +
                          "</leed>" +
                      "</leeds>" +
                    "</Feed>";
                XDocument xmlDoc = XDocument.Parse(xml);
                var results = from feed in xmlDoc.Descendants("Feed")
                              let Repairer = feed.Elements("Control").FirstOrDefault()
                              let job = feed.Descendants("leed").FirstOrDefault()
                              select new Job
                              {
                                  Username = (string)Repairer.Element("UserName"),
                                  Password = (string)Repairer.Element("Password"),
                                  IncidentDetail = string.Join(",",job.Element("IncidentDetails").Elements().Select(x => x.Value)),
                                  ClientsName = (string)job.Elements("ClientsName").FirstOrDefault(),
                                  IncidentName = (string)job.Descendants("IncidentName").FirstOrDefault()
                              };
            }
        }
        public class Job
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int leedid { get; set; }
            public int Reference { get; set; }
            public string IncidentDate { get; set; }
            public string IncidentDetail { get; set; }
            public string ClientsID { get; set; }
            public string ClientsName { get; set; }
            public string IncidentID { get; set; }
            public string IncidentName { get; set; }
        }
    }
    ​
