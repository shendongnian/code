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
                var results = xmlDoc.Descendants("Feed").Select(feed => 
                              feed.Descendants("leed").Select(job => new Job
                              {
                                  Username = (string)feed.Elements("Control").FirstOrDefault().Element("UserName"),
                                  Password = (string)feed.Elements("Control").FirstOrDefault().Element("Password"),
                                  IncidentDetail = string.Join(",", job.Element("IncidentDetails").Elements().Select(x => x.Value)),
                                  ClientsName = (string)job.Elements("ClientsName").FirstOrDefault(),
                                  IncidentName = (string)job.Descendants("IncidentName").FirstOrDefault()
                              }).ToList()).ToList();
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
