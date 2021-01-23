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
                    "<ParentNode>" + 
                     "<Child1>Child1 + Data</Child1>" +
                     "<Child2>" +
                       "<grandChild1 type=\"grandChild1attributevalue\">" +
                         "<grangrandChild1>grangrandChild1 data</grangrandChild1>" +
                         "<grangrandChild2>grangrandChild2 data</grangrandChild2>" +
                       "</grandChild1>" +
                     "</Child2>" +
                     "<child3>child 3 Data</child3>" +
                     "</ParentNode>" +
                     "</Root>";
                XDocument doc = XDocument.Parse(xml);
                XElement parent = doc.Descendants("ParentNode").FirstOrDefault();
                var family = GetChildren(parent);
            }
            static object GetChildren(XElement parent)
            {
                return parent.Elements().Select(x => new
                {
                    type = x.Name.LocalName,
                    value = x.Value,
                    descendants = GetChildren(x)
                }).ToList();
            }
        }
    }
