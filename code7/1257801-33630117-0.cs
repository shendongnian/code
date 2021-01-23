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
                    "<img src=\"alt.png\" class=\"absmiddle\" alt=\"\" />" +
                    "<img src=\"alt.png\" class=\"absmiddle\" />" +
                    "</Root>";
                XElement root = XElement.Parse(xml);
                int count = root.Descendants("img").Where(x => x.Attribute("alt") == null || x.Attribute("alt").Value.Length == 0).Count();
            }
        }
    }
    ​
