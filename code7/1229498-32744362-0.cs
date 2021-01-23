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
                string response =
                        "<path>" +
                            "<time>1234</time>" +
                            "<price>40</price>" +
                            "<length>7680</length>" +
                            "<transportTakes>2</transportTakes>" +
                            "<actions>" +
                                "<walk>" +
                                    "<length>50</length>" +
                                    "<toStop>24</toStop>" +
                                    "<comment>Information</comment>" +
                                "</walk>" +
                                "<pass>" +
                                    "<length>2350</length>" +
                                    "<stops>24,785,234,644,53,89</stops>" +
                                    "<routes>67,46,275,365,24</routes>" +
                                    "<comment>Information</comment>" +
                                "</pass>" +
                             "</actions>" +
                        "</path>";
                var xDoc = XDocument.Parse(response);
                Data.Path path = xDoc.Elements("path").Select(res =>  new Data.Path() {
                                      Time = (Int32?)res.Element("time"),
                                      Price = (Int32?)res.Element("price"),
                                      Length = (Int32?)res.Element("length"),
                                      TransportTakes = (Int32?)res.Element("transportTakes"),
                                      ActionsList = res.Elements("actions").Elements().Select(nextRes => new PathActions()
                                      {
                                          XName = (String)nextRes.Name.LocalName,
                                          LengthActions = (Int32?)nextRes.Element("length"),
                                          ToStop = (Int32?)nextRes.Element("toStop"),
                                          Routes = (String)nextRes.Element("routes"),
                                          FromStop = (Int32?)nextRes.Element("fromStop"),
                                          Comment = (String)nextRes.Element("comment")
                                      }).ToList(),
                                  }).FirstOrDefault();
            }
        }
        public static class Data
        {
            public class Path
            {
                public Int32? Time { get; set; }
                public Int32? Price { get; set; }
                public Int32? Length { get; set; }
                public Int32? TransportTakes { get; set; }
                public List<PathActions> ActionsList { get; set; }
            }
        }
        public class PathActions
        {
            public string XName { get; set; }
            public Int32? LengthActions { get; set; }
            public Int32? ToStop { get; set; }
            public String Routes { get; set; }
            public Int32? FromStop { get; set; }
            public string Comment { get; set; }
        }
    }
    ​
