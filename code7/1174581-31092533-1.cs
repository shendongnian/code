    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                "<Root>" +
                "<mat id=\"4230348\">" +
                   "<home id=\"2339086\"/><away id=\"2339218\"/>" +
                   "<os/>" +
                "</mat>" +
                "<mat id=\"4230349\">" +
                   "<home id=\"2339086\"/><away id=\"2339218\"/>" +
                   "<os/>" +
                "</mat>" +
                "<mat id=\"4230350\">" +
                   "<home id=\"2339086\"/><away id=\"2339218\"/>" +
                   "<os>info</os>. " +
                "</mat>" +
                "<mat id=\"4230351\">" +
                   "<home id=\"2339086\"/><away id=\"2339218\"/>" +
                   "<os/>" +
                "</mat>" +            
                "</Root>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Descendants("mat")
                   .Select(x => new {
                       matId = x.Attribute("id").Value,
                       homeId = x.Element("home").Attribute("id").Value,
                       awayId = x.Element("away").Attribute("id").Value,
                       os = (string)x.Element("os")
                   })
                .ToList();
            }
        }
    }
    ​
