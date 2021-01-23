    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication82
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<VIDEOS>" +
                        "<VIDEO>" +
                            "<ID>1</ID>" +
                            "<NAME>AAA</NAME>" +
                            "<ACTORS>" +
                                "<ACTOR>" +
                                    "<NAME>AAA</NAME>" +
                                    "<URL>www.aaa.com</URL>" +
                                "</ACTOR>" +
                                "<ACTOR>" +
                                    "<NAME>BBB</NAME>" +
                                    "<URL>www.bbb.com</URL>" +
                                "</ACTOR>" +
                                "<ACTOR>" +
                                    "<NAME>CCC</NAME>" +
                                    "<URL>www.ccc.com</URL>" +
                                "</ACTOR>" +
                            "</ACTORS>" +
                        "</VIDEO>" +
                        "<VIDEO>" +
                            "<ID>2</ID>" +
                            "<NAME>BBB</NAME>" +
                            "<ACTORS>" +
                                "<ACTOR>" +
                                    "<NAME>AAA</NAME>" +
                                    "<URL>www.aaa.com</URL>" +
                                "</ACTOR>" +
                                "<ACTOR>" +
                                    "<NAME>DDD</NAME>" +
                                    "<URL>www.ddd.com</URL>" +
                                "</ACTOR>" +
                                "<ACTOR>" +
                                    "<NAME>EEE</NAME>" +
                                    "<URL>www.eee.com</URL>" +
                                "</ACTOR>" +
                            "</ACTORS>" +
                        "</VIDEO>" +
                        "<VIDEO>" +
                            "<ID>3</ID>" +
                            "<NAME>CCC</NAME>" +
                            "<ACTORS>" +
                                "<ACTOR>" +
                                    "<NAME>CCC</NAME>" +
                                    "<URL>www.ccc.com</URL>" +
                                "</ACTOR>" +
                                "<ACTOR>" +
                                    "<NAME>BBB</NAME>" +
                                    "<URL>www.bbb.com</URL>" +
                                "</ACTOR>" +
                                "<ACTOR>" +
                                    "<NAME>EEE</NAME>" +
                                    "<URL>www.eee.com</URL>" +
                                "</ACTOR>" +
                            "</ACTORS>" +
                        "</VIDEO>" +
                    "</VIDEOS>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("VIDEO").Select(x => new {
                    id = (int)x.Element("ID"), 
                    name = (string)x.Element("NAME"),
                    actors = x.Descendants("ACTOR").Select(y => new {
                        name = (string)y.Element("NAME"),
                        url = (string)y.Element("URL")
                    }).ToList()
                }).ToList();
            }
         
        }
    }
