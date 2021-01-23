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
                "<mat id=\"4230348\">" +
                   "<home id=\"2339086\"/><away id=\"2339218\"/>" +
                   "<os/>" +
                "</mat>";
                XDocument doc = XDocument.Parse(input);
                XElement mat = doc.Descendants("mat").FirstOrDefault();
                string homeId = mat.Element("home").Attribute("id").Value;
                string awayId = mat.Element("away").Attribute("id").Value;
            }
        }
    }
    ​
