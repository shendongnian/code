    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<Company>" +
                      "<row Id=\"1\" Name=\"ABC\" StartDate=\"2000-03-01\" />" +
                      "<row Id=\"2\" Name=\"XYZ\" StartDate=\"2001-13-11\" />" +
                    "</Company>";
                XDocument doc = XDocument.Parse(xml);   // use Load to read from file
                var rows = doc.Descendants("row").Select(x => new
                {
                    id = (int)x.Attribute("Id"),
                    name = (string)x.Attribute("Name"),
                    startDate = (DateTime)x.Attribute("StartDate")
                }).ToList();
                //using xmltextreader
                List<Row> rows2 = new List<Row>();
                StringReader sReader = new StringReader(xml);
                XmlTextReader reader = new XmlTextReader(sReader);
                while(!reader.EOF)
                {
                    if (reader.Name != "row")
                    {
                        reader.ReadToFollowing("row");
                    }
                    if (!reader.EOF)
                    {
                        XElement newRow = (XElement)XElement.ReadFrom(reader);
                        rows2.Add(new Row() { Id = (int)newRow.Attribute("Id"), name = (string)newRow.Attribute("Name"), startDate = (DateTime)newRow.Attribute("StartDate") });
                    }
                }
            }
        }
        public class Row
        {
            public int Id { get; set; }
            public string name { get; set; }
            public DateTime startDate { get; set; }
        }
    }
    ​
