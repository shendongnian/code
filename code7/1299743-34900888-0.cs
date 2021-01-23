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
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<SW.CodeBlock ID=\"0\">" +
                        "<SW.CompileUnit ID=\"1\">" +
                            "<AttributeList>" +
                                "<NetworkSource>" +
                                    "<FlgNet xmlns=\"http://www.TEST.com\">" +
                                        "<Parts> </Parts>" +
                                    "</FlgNet>" +
                                "</NetworkSource>" +
                            "</AttributeList>" +
                        "</SW.CompileUnit>" +
                        "<SW.CompileUnit ID=\"2\">" +
                            "<AttributeList>" +
                                 "<NetworkSource>" +
                                     "<FlgNet xmlns=\"http://www.TEST.COM\">" +
                                        "<Parts> </Parts>" +
                                     "</FlgNet>" +
                                 "</NetworkSource>" +
                            "</AttributeList>" +
                        "</SW.CompileUnit>" +
                    "</SW.CodeBlock>";
                XDocument doc = XDocument.Parse(xml);
                var compileUnits = doc.Descendants("SW.CompileUnit").Select(x => new {
                    ID = (string)x.Attribute("ID"),
                    parts = x.Descendants().Where(y => y.Name.LocalName == "Parts").FirstOrDefault()
                }).ToList();
                foreach (var compileUnit in compileUnits)
                {
                    compileUnit.parts.Add(new XElement(compileUnit.parts.Name.Namespace + "ID", compileUnit.ID));
                }
            }
        }
    }
