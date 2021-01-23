    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<object> values = new List<object>();
                string xml =
                    "<Root xmlns:xsi = \"abc\">" +
                        "<Value xsi:type=\"xsd:short\">0</Value>" +
                        "<Value xsi:type=\"xsd:string\">foo</Value>" +
                        "<Value xsi:type=\"xsd:boolean\">false</Value>" +
                    "</Root>";
                XElement root = XElement.Parse(xml);
                XNamespace ns = root.GetDefaultNamespace();
                foreach(XElement value in root.Descendants("Value"))
                {
                    string _type = (string)value.Attributes().Where(x => x.Name.LocalName == "type").FirstOrDefault();
                    switch (_type)
                    {
                        case "xsd:short"  :
                            values.Add((short)value);
                            break;
                        case "xsd:string":
                            values.Add((string)value);
                            break;
                        case "xsd:boolean":
                            values.Add((Boolean)value);
                            break;
                    }
                }
            }
        }
    }
