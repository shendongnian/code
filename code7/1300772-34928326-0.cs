    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                    "<root>" +
                        "<register_map>" +
                            "<Register ID=\"1\" Index=\"0x100000\" DataType=\"0x0007\" ObjectType=\"0x07\" Name=\"Device Type\"/>" +
                            "<Register ID=\"2\" Index=\"0x100100\" DataType=\"0x0005\" ObjectType=\"0x07\" Name=\"Error Register\"/>" +
                        "</register_map>" +
                    "</root>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("Register").Select(x => new {
                    id = (int)x.Attribute("ID"),
                    index = int.Parse(x.Attribute("Index").Value.Substring(2), NumberStyles.HexNumber,  CultureInfo.CurrentCulture),
                    dataType = int.Parse(x.Attribute("DataType").Value.Substring(2), NumberStyles.HexNumber, CultureInfo.CurrentCulture),
                    objectType = int.Parse(x.Attribute("ObjectType").Value.Substring(2), NumberStyles.HexNumber, CultureInfo.CurrentCulture),
                    name = (string)x.Attribute("Name")
                }).ToList();
            }
        }
    }
