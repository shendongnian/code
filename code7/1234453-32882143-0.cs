    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication52
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<Library xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                      "<Songs>" +
                        "<Song>" +
                          "<Title>High Hopes</Title>" +
                          "<Genres>" +
                            "<Genre>Rock</Genre>" +
                            "<Genre>American</Genre>" +
                          "</Genres>" +
                         "</Song>" +
                        "<Song>" +
                          "<Title>Imagine</Title>" +
                          "<Genres>" +
                            "<Genre>Pop</Genre>" +
                            "<Genre>Unplugged</Genre>" +
                          "</Genres>" +
                        "</Song>" +
                      "</Songs>" +
                    "</Library>";
                XElement library = XElement.Parse(input);
                var results = library.Descendants("Song").Select(x => new
                {
                    title = x.Element("Title").Value,
                    genres = x.Descendants("Genre").Select(y => new {
                        genere = y.Value
                    }).ToList()
                }).ToList();
            }
        }
    }
