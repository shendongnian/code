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
                PrimaryTile pt = new PrimaryTile() {
                    time = DateTime.Parse("11/21/2015 8:15 AM"),
                    message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore.",
                    message2 = " At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.",
                    branding = "name",
                    appName = "HoL"
                };
                XmlDocument doc = CreateTiles(pt);
            }
            public static XmlDocument CreateTiles(PrimaryTile primaryTile)
            {
                XDocument xDoc = new XDocument(
                    new XElement("tile", new XAttribute("version", 3),
                        new XElement("visual",
                    // Small Tile 
                            new XElement("binding", new XAttribute("branding",
                            primaryTile.branding), new XAttribute("displayName", primaryTile.appName), new XAttribute("template", "TileSmall"),
                                new XElement("group",
                                    new XElement("subgroup",
                                        new XElement("text", primaryTile.time, new XAttribute("hint-style", "caption")),
                                            new XElement("text", primaryTile.message, new
                                            XAttribute("hint-style", "captionsubtle"), new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                                        )
                                    )
                                ),
                    // Medium Tile 
                                new XElement("binding", new XAttribute("branding", primaryTile.branding),
                                    new XAttribute("displayName", primaryTile.appName), new XAttribute("template", "TileMedium"),
                                        new XElement("group", new XElement("subgroup",
                                            new XElement("text", primaryTile.time, new XAttribute("hint-style", "caption")),
                                                new XElement("text", primaryTile.message, new XAttribute("hint-style", "captionsubtle"),
                                                    new XAttribute("hint-wrap", true), new XAttribute("hint-maxLines", 3))
                                           )
                                      )
                                 )
                            )
                        )
                    );
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xDoc.ToString());
                return xmlDoc;
            }
        }
        public class PrimaryTile
        {
            public DateTime time { get; set; } 
            public string message { get; set; }
            public string message2 { get; set; }
            public string branding { get; set; }
            public string appName { get; set; }
        }
    }
    ​
