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
                    "<BookStore>" +
                    "<Book Id=\"1\">" +
                      "<Subject>" +
                        "<Rank ID=\"Chemistry\">" +
                            "<a>A</a>" +
                        "</Rank>" +
                        "<Rank ID=\"Physics\">" +
                            "<b>B</b>" +
                        "</Rank>" +
                      "</Subject>" +
                    "</Book>" +
                    "<Book Id=\"2\">" +
                      "<Subject>" +
                        "<Rank ID=\"Science\">" +
                            "<a>C</a>" +
                        "</Rank>" +
                        "<Rank ID=\"English\">" +
                            "<b>D</b>" +
                        "</Rank>" +
                      "</Subject>" +
                    "</Book>" +
                    "</BookStore>";
                XDocument xmlSourceFile = XDocument.Parse(input);
                var platformNodeList1 = xmlSourceFile.Descendants("Rank").Select(x => x.Attribute("ID").Value).ToList();
            }
        }
    }​
