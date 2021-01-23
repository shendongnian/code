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
                    "<Module>" +
                      "<Variable Name=\"Variable1\" Value=\"True\" />" +
                      "<Variable Name=\"Variable2\" Value=\"True\" />" +
                      "<Variable Name=\"Variable3\" Value=\"True\" />" +
                      "<Task Name=\"Task1\">" +
                        "<Variable Name=\"Task1Variable1\" Value =\"True\" />" +
                        "<Variable Name=\"Task1Variable2\" Value =\"True\" />" +
                      "</Task>" +
                      "<Task Name=\"Task2\">" +
                        "<Variable Name=\"Task2Variable1\" Value =\"True\" />" +
                        "<Variable Name=\"Task2Variable2\" Value =\"True\" />" +
                      "</Task>" +
                    "</Module>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Elements("Module").Select(m => new {
                    variables = m.Elements("Variable").Select(n => new {
                       name = (string)n.Attribute("Name"),
                       value = (string)n.Attribute("Value")
                    }).ToList(),
                    tasks = m.Elements("Task").Select(o => new {
                        name = (string)o.Attribute("Name"),
                        variables = o.Elements("Variable").Select(p => new {
                            name = (string)p.Attribute("Name"),
                            value = (string)p.Attribute("Value")
                        }).ToList()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
