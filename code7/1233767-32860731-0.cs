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
                    "<namespace xmlns=\"http://www.find.org/schemas/\">" +
                      "<date>2015</date>" +
                      "<xhtml:link xmlns:xhtml=\"xhtml:link\" rel=\"alternate\" />" +
                      "<xhtml:link xmlns:xhtml=\"xhtml:link\" rel=\"alternate\" />" +
                      "<xhtml:link xmlns:xhtml=\"xhtml:link\" rel=\"alternate\" />" +
                    "</namespace>";
                XDocument xdoc = XDocument.Parse(input);
                List<XElement> links = xdoc.Descendants().Where(x => x.Name.LocalName == "link").ToList();
            }
        }
    }​
