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
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?><strings></strings>";
                XDocument doc = XDocument.Parse(header);
                XElement strings = (XElement)doc.FirstNode;
                List<List<string>> buttons = new List<List<string>>() {
                                    new List<string>() {"progressBTn", "Next"},
                                    new List<string>() {"reverseBth", "Back"},
                                    new List<string>() {"largeText", "This is Large Text"}
                };
                foreach(List<string> button in buttons)
                {
                    strings.Add(
                        new XElement("string", new object[] {
                            new XAttribute("name", button[0]),
                            button[1]
                        }));
                }
                   
            }
        }
    }
