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
                    "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                        "<result>" +
                         "<success>0</success>" +
                         "<successid/>" +
                         "<errors>" +
                            "<error>Error 1: Too Many Characters</error>" +
                            "<error>Error 2: Invalid Entry</error>" +
                         "</errors>" +
                        "</result>";
                XDocument result = XDocument.Parse(xml);
                var parsed = result.Elements().Select(x => new {
                    success = (int)x.Element("success"),
                    errors = x.Descendants("error") == null ? null : x.Descendants("error").Select(y => y.Value).ToList()
                }).FirstOrDefault();
            }
        }
    }
    ​
