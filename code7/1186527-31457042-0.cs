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
                "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "<Root>" +
                  "<Field id =\"1\"></Field>" +
                  "<Field id =\"2\"></Field>" +
                  "<Field id =\"3\"></Field>" +
                  "<Field id =\"1\"></Field>" +
                  "<Field id =\"2\"></Field>" +
                  "<Field id =\"3\"></Field>" +
                  "<Field id =\"4\"></Field>" +
                  "<Field id =\"2\"></Field>" +
                  "<Field id =\"3\"></Field>" +
                  "<Field id =\"4\"></Field>" +
                "</Root>";
                XDocument xdoc = XDocument.Parse(input);
                var xtra =
                    xdoc.Descendants("Field")
                    .GroupBy(g => g.Attribute("id").Value)
                    .Select(x => x.FirstOrDefault())
                    .ToList();
            }
        }
    }
    ​
