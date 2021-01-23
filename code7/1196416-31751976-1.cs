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
                    "<html>" +
                    "<body>" +
                    "<div>" +
                    "<div>" +
                    "<h2>some text1</h2>" +
                    "<h2>some text</h2>" +
                    "</div>" +
                    "</div>" +
                    "<div>" +
                    "<table>" +
                    "<tr>" +
                    "<td>some cell</td>" +
                    "<td>some cell</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>some cell</td>" +
                    "</tr>" +
                    "</table>" +
                    "</div>" +
                    "<div>" +
                    "<h1>some text</h1>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                XDocument doc = XDocument.Parse(input);
                XElement body = doc.Descendants("body").FirstOrDefault();
                List<int> indexes = new List<int>();
                AddIndex(body, indexes);
            }
            static void AddIndex(XElement elements, List<int> indexes)
            {
                indexes.Add(0);
                foreach (XElement element in elements.Elements())
                {
                    indexes[indexes.Count - 1] += 1;
                    element.Add(new XAttribute("index", string.Join(".",indexes.Select(x => x.ToString()))));
                    if (element.HasElements)
                    {
                        AddIndex(element, indexes);
                    }
                }
                indexes.RemoveAt(indexes.Count - 1);
            }
        }
    }
    ​​
