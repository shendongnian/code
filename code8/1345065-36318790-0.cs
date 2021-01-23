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
                    "<Root>" +
                    "<RNC id=\"00\">" +
                        "<abc1>" +
                        "</abc1>" +
                        "<abc2>" +
                        "</abc2>" +
                    "</RNC>" +
                    "<RNC id=\"01\">" +
                        "<abc3>" +
                        "</abc3>" +
                        "<abc4>" +
                        "</abc4>" +
                    "</RNC>" +
                    "<RNC id=\"01\">" +
                        "<abc5>" +
                        "</abc5>" +
                        "<abc6>" +
                        "</abc6>" +
                    "</RNC>" +
                    "</Root>";
                XElement root = XElement.Parse(xml);
                var groups = root.Elements("RNC").GroupBy(x => x.Attribute("id").Value).ToList();
                foreach (var group in groups)
                {
                    if (group.Count() > 1)
                    {
                        var all = group.AsEnumerable().ToList();
                        for (int index = all.Count() - 2; index >= 0; index--)
                        {
                            all[index].Add(all[index + 1].Elements());
                            all[index + 1].RemoveAll();
                        }
                    }
                    
                }
            }
        }
    }
