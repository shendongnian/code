    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                GetNode((XElement)doc.FirstNode);
            }
            static void GetNode(XElement element)
            {
                // Loop through the XML nodes until the leaf is reached.
                // Add the nodes to the TreeView during the looping process.
                List<XElement> children = element.Elements().ToList();
                var groups = element.Elements().GroupBy(x => x.Name.LocalName).ToList();
                foreach (var group in groups)
                {
                    string tagName = group.Key;
                    List<XElement> elements = group.ToList();
                    for (int index = group.Count() - 1; index >= 0; index--)
                    {
                        GetNode(elements[index]);
                        XElement newElement = new XElement(tagName + "_" + (index + 1).ToString(), new object[] { elements[index].Attributes(), elements[index].Value, elements[index].Elements() });
                        elements[index].ReplaceWith(newElement);
                       
                    }
                }
            }
        }
    }
