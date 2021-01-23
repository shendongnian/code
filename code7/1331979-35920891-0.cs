    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication81
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<data>" +
                      "<subdata>" +
                        "<datatype id=\"1\" name=\"data1\">" +
                        "<xdim>2</xdim>" +
                        "<ydim>1</ydim>" +
                        "</datatype>" +
                        "<datatype id=\"2\" name=\"data2\">" +
                        "<xdim>3</xdim>" +
                        "<ydim>4</ydim>" +
                        "</datatype>" +
                      "</subdata>" +
                    "</data>";
                XElement data = XElement.Parse(xml);
                var results = data.Descendants("subdata").Elements()
                    .GroupBy(x => x.Name.LocalName)
                    .Select(x => new
                    {
                        name = x.Key,
                        value = x.Select(y => (string)y).ToList(),
                        attributes = x.Attributes()
                           .Select(y => new {name = y.Name.LocalName, y.Value})
                           .GroupBy(y => y.name, z => z.Value)
                           .ToDictionary(y => y.Key, z => z.ToList())
                    }).ToList();
            }
        }
    }
