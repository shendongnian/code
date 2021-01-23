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
                    "<setup name=\"NEW\">" +
                        "<master comment=\"\" gui_namewidth=\"160\" gui_valwidth=\"40\" name=\"MASTER\" type=\"u8\">" +
                            "<item comment=\"\" name=\"Name\" value=\"0\"/>" +
                        "</master>" +
                        "<enum comment=\"\" gui_namewidth=\"160\" gui_valwidth=\"40\" name=\"Name\" type=\"u8\">" +
                            "<item comment=\"\" name=\"1\" value=\"0\"/>" +
                        "</enum>" +
                    "</setup>";
                XDocument doc = XDocument.Parse(xml);
                XElement setup = doc.Element("setup");
                setup.ReplaceAttributes(new object[] { new XAttribute("CRC", "0x1244343"), setup.Attributes() });
            }
        }
    }
