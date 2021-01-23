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
                 "<Root>" +
                   "<Building>" +
                      "<Name>Bldg 1</Name>" +
                      "<Room>" +
                        "<Name>Room 1</Name>" +
                        "<Table>" +
                            "<Name>Table 1</Name>" +
                        "</Table>" +
                      "</Room>" +
                      "<Room>" +
                        "<Name>Room 2</Name>" +
                        "<Table>" +
                            "<Name>Table 1</Name>" +
                        "</Table>" +
                      "</Room>" +
                   "</Building>" +
                   "<Building>" +
                      "<Name>Bldg 2</Name>" +
                      "<Room>" +
                        "<Name>Room 1</Name>" +
                        "<Table>" +
                            "<Name>Table 1</Name>" +
                        "</Table>" +
                      "</Room>" +
                      "<Room>" +
                        "<Name>Room 2</Name>" +
                        "<Table>" +
                            "<Name>Table 1</Name>" +
                        "</Table>" +
                      "</Room>" +
                   "</Building>" +
                "</Root>";
                XElement root = XElement.Parse(input);
                var results = root.Descendants("Building").Select(x => new
                {
                    name = x.Element("Name").Value,
                    rooms = x.Elements("Room").Select(y => new
                    {
                        name = y.Element("Name").Value,
                        Tables = y.Elements("Table").FirstOrDefault().Element("Name").Value
                    }).ToList()
                }).ToList();
            }
        }
    }
