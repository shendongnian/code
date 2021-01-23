    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication53
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<Root>" + 
                        "<Group>" +
                            "<Day name=\"Mo\">" +
                                "<title>Foo</title>" +
                            "</Day>" +
                            "<Day name=\"Tu\">" +
                                "<title>Foo</title>" +
                                "<title>Bar</title>" +
                            "</Day>" +
                            "<Day name=\"We\">" +
                                "<title>Foo</title>" +
                            "</Day>" +
                            "<Day name=\"Su\">" +
                                "<title>Foo</title>" +
                            "</Day>" +
                        "</Group>" +
                     "</Root>";
                XElement root = XElement.Parse(xml);
                var groups = root.Descendants("Group").Elements("Day").Select(x => new
                {
                    titles = x.Descendants("title").Select(y => new {
                       day = x.DescendantsAndSelf().FirstOrDefault(),
                       title = (string)y
                    }).ToList()
                }).SelectMany(z => z.titles).GroupBy(a => a.title).Select(b => new XElement("Day", new object[] {
                        new XAttribute("name", string.Join(",", b.Select(c => c.day.Attribute("name").Value).ToArray())),
                        new XElement("title",b.FirstOrDefault().title)
                    })).ToList();
                root.Element("Group").ReplaceWith(new XElement("Group", groups));
            }
        }
    }
