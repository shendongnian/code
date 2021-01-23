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
                    "<psmsmanifiest version=\"2\" lastmodified=\"2015-08-06 03:53:06.207\">" +
                      "<rules>" +
                        "<!--sample for runtime data provider-->" +
                        "<rule ruleid=\"8504dcad-f748-4add-9e95-239d5382f1c6\" dataprovider=\"runtime\">" +
                          "<attributes>" +
                            "<attribute name=\"platform.attibute1.value\" type=\"int\">" +
                              "<conditions>" +
                                "<condition type=\"healthy\" operator=\"greaterthan\">100></condition>" +
                                "<condition type=\"unhealthy\" operator=\"greaterthanequal\">100></condition>" +
                              "</conditions>" +
                            "</attribute>" +
                            "<attribute name=\"platform.attibute2.value\" type=\"int\">" +
                              "<conditions>" +
                                "<condition type=\"healthy\" operator=\"greaterthan\">100></condition>" +
                                "<condition type=\"unhealthy\" operator=\"greaterthanequal\">100></condition>" +
                              "</conditions>" +
                            "</attribute>" +
                          "</attributes>" +
                        "</rule>" +
                      "</rules>" +
                    "</psmsmanifiest>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("rule").Select(x => new
                {
                    ruleid = x.Attribute("ruleid").Value,
                    dataprovider = x.Attribute("dataprovider").Value,
                    attributes = x.Descendants("attribute").Select(y => new
                    {
                        name = y.Attribute("name").Value,
                        conditions = y.Descendants("condition").Select(z => new
                        {
                            _type = z.Attribute("type").Value,
                            _operator = z.Attribute("operator").Value,
                            _value = z.Value
                        }).ToList()
                    }).ToList()
                }).ToList();
            }
        }
    }
    ​
