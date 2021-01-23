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
                    "<Database>" +
                      "<Member>" +
                        "<Name>PersonA</Name>" +
                        "<Rank>RankIWant</Rank>" +
                      "</Member>" +
                      "<Member>" +
                        "<Name>PersonB</Name>" +
                        "<Rank>RankIDontWant</Rank>" +
                      "</Member>" +
                    "</Database>";
                XElement database = XElement.Parse(xml);
                XElement query = database.Elements("Member")
                    .Where(x => x.Element("Rank").Value == "RankIWant").FirstOrDefault();
            }
        }
    }
