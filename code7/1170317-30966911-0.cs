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
                string input =
                    "<Data>" +
                      "<Report>" +
                        "<Machine name=\"hostA\">" +
                          "<MachineInfo location=\"LA\">" +
                            "<function name=\"run\">Late</function>" +
                            "<function name=\"status\">Complete</function>" +
                            "<function name=\"date\">2015-06-14</function>" +
                          "</MachineInfo>" +
                          "<RepItem name=\"1488\" direction=\"NS\">" +
                            "<Desc>None Found</Desc>" +
                            "<Status Int=\"A12\">Uplink</Status>" +
                          "</RepItem>" +
                          "<RepItem name=\"1489\" direction=\"S\">" +
                            "<Desc>31Ghz Ant at 285ft.</Desc>" +
                            "<Status Int=\"D5\">Active</Status>" +
                          "</RepItem>" +
                          "<RepItem name=\"1438\" direction=\"W\">" +
                            "<Desc>West N. Oc. Backup</Desc>" +
                            "<Status Int=\"A11\">Disabled</Status>" +
                          "</RepItem>" +
                          "<RepItem name=\"1141\" direction=\"SE\">" +
                            "<Desc>MDT Co.</Desc>" +
                            "<Status Int=\"B7\">Active</Status>" +
                          "</RepItem>" +
                        "</Machine>" +
                        "<Machine name=\"hostB\">" +
                          "<MachineInfo location=\"E. LA\">" +
                            "<function name=\"run\">Late</function>" +
                            "<function name=\"status\">Complete</function>" +
                            "<function name=\"date\">2015-06-14</function>" +
                          "</MachineInfo>" +
                          "<RepItem name=\"1488\" direction=\"NS\">" +
                            "<Desc>None Found</Desc>" +
                            "<Status Int=\"A12\">Down</Status>" +
                          "</RepItem>" +
                          "<RepItem name=\"1489\" direction=\"S\">" +
                            "<Desc>31Ghz Ant at 285ft.</Desc>" +
                            "<Status Int=\"D5\">Active</Status>" +
                          "</RepItem>" +
                          "<RepItem name=\"1438\" direction=\"W\">" +
                            "<Desc>West N. Oc. Backup</Desc>" +
                            "<Status Int=\"A11\">Disabled</Status>" +
                          "</RepItem>" +
                          "<RepItem name=\"1141\" direction=\"SE\">" +
                            "<Desc>MDT Co.</Desc>" +
                            "<Status Int=\"B7\">Active</Status>" +
                          "</RepItem>" +
                        "</Machine>" +
                      "</Report>" +
                    "</Data>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("Machine")
                    .Select(x => new {
                        name = x.Attribute("name").Value,
                        info = new {
                            machineInfo = x.Element("MachineInfo").Attribute("location").Value,
                            functions = x.Element("MachineInfo").Elements("function").Select(y => y.Value).ToList()
                        },
                        repItem = x.Elements("RepItem")
                            .Select(y => new {
                                name = y.Attribute("name").Value, 
                                direction = y.Attribute("direction").Value,
                                description = y.Element("Desc").Value,
                                status = y.Element("Status").Value
                            }).ToList()
                    })
                    .ToList();
            }
        }
    }
    ​
