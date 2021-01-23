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
                    "<Data>" +
                      "<Organisation>" +
                    "<Name>Accident Compensation Corporation</Name>" +
                        "<ID> 022 12345678 </ID>" +
                        "<Address> 220 Bunny Street</Address>" +
                        "</Organisation>" +
                      "<Organisation>" +
                        "<Name>Test 2</Name>" +
                        "<Address> 50 Lambton Quay</Address>" +
                        "<ID> 021 8972468739 </ID>" +
                      "</Organisation>" +
                    "</Data>";
                XElement data = XElement.Parse(xml);
                List<Organisation> organizations = new List<Organisation>();
                organizations = data.Descendants().Where(x => x.Name.LocalName == "Organisation").Select(y => new Organisation()
                {
                    name = (string)y.Element("Name"),
                    address = (string)y.Element("Address"),
                    id = (string)y.Element("ID")
                }).ToList();
                
            }
        }
        public class Organisation
        {
            public string id;
            public string name;
            public string address;
            public Organisation() { }
            public Organisation(string id, string name, string address)
            {
                this.id = id;
                this.name = name;
                this.address = address;
            }
        }
    }
