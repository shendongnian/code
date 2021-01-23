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
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                    "<park>" +
                        "<name>DEPO Name</name>" +
                        "<numberOfTrams>120</numberOfTrams>" +
                        "<minStopAtDepo>3:0</minStopAtDepo>" +
                        "<timeBetweenArrivals>0:5</timeBetweenArrivals>" +
                        "<allowedSwithing>true</allowedSwithing>" +
                        "<maxDepartureDelay>0.3</maxDepartureDelay>" +
                        "<stops>" +
                            "<stop sname=\"A\" minStopTime=\"0:30\">" +
                                "<connections>" +
                                    "<connection stopConnected=\"A*\" time=\"3:0\"></connection>" +
                                "</connections>" +
                            "</stop>" +
                            "<stop sname=\"A*\" minStopTime=\"0:30\">" +
                                "<connections>" +
                                    "<connection stopConnected=\"B*\" time=\"3:0\"></connection>" +
                                "</connections>" +
                            "</stop>" +
                            "<stop sname=\"B\" minStopTime=\"0:30\">" +
                            "<connections>" +
                                "<connection stopConnected=\"J\" time=\"3:0\"></connection>" +
                                "<connection stopConnected=\"GG*\" time=\"2:0\"></connection>" +
                            "</connections>" +
                            "</stop>" +
                            "<stop sname=\"T\" minStopTime=\"0:30\">" +
                                "<connections>" +
                                    "<connection stopConnected=\"S\" time=\"2:0\"></connection>" +
                                    "<connection stopConnected=\"T*\" time=\"2:0\"></connection>" +
                                    "<connection stopConnected=\"U\" time=\"2:0\"></connection>" +
                                    "<connection stopConnected=\"T\" time=\"1:0\"></connection>" +
                                "</connections>" +
                            "</stop>" +
                        "</stops>" +
                    "</park>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("stops").FirstOrDefault().Elements("stop").Select(x => new
                {
                    sname = x.Attribute("sname").Value,
                    minStopTime = x.Attribute("minStopTime").Value,
                    connections = x.Descendants("connection").Select(y => new {
                        stopConnected = y.Attribute("stopConnected").Value,
                        time = y.Attribute("time").Value
                    }).ToList()
                }).ToList();
            }
        }
    }
