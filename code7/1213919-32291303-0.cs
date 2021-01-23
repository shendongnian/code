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
                    "<Root>" +
                        "<td class=\"artist\">" +
                          "<div class=\"wrapper ellipsis\">" +
                            "<a class=\"evt-click\" href=\"/artist/7\" data-target=\"artist\" itemprop=\"byArtist\">Jamiroquai</a>" +
                          "</div>" +
                        "</td>" +
                        "<td class=\"album\">" +
                          "<div class=\"wrapper ellipsis\">" +
                            "<a class=\"evt-click\" href=\"/album/98952\" itemprop=\"inAlbum\" data-target=\"album\" >A Funk Odyssey</a>" +
                          "</div>" +
                        "</td>" +
                        "<td class=\"length\">" +
                          "<div class=\"wrapper\" data-target=\"length\"></div>" +
                        "</td>" +
                        "<td class=\"popularity\" title=\"By popularity:7.85 / 10\">" +
                          "<span class=\"note\" data-target=\"note\"></span>" +
                        "</td>" +
                        "<td class=\"added\">" +
                          "<div class=\"wrapper ellipsis timestamp\" data-target=\"added\">" +
                            "05:23" +
                          "</div>" +
                        "</td>" +
                    "</Root>";
                XElement doc = XElement.Parse(input);
                var results = doc.Descendants("div").Where(x => x.Attribute("class").Value == "wrapper ellipsis timestamp").FirstOrDefault().Value;
             }
        }
    }
    ​
