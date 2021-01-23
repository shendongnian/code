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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var conferencia = doc.Descendants().Select(x => new {
                    info = x.Elements("info").Select(y => new {
                        loc_img = (string)y.Element("loc_img"),
                        infor = (string)y.Element("infor")
                    }).ToList(),
                    keynoteSpeaker = x.Elements("KeynoteSpeaker").Select(y => new {
                        id = (string)y.Attribute("id"),
                        foto = (string)y.Element("foto"),
                        nome = (string)y.Element("nome"),
                        organizacao = (string)y.Element("organizacao"),
                        funcao = (string)y.Element("funcao"),
                        _abstract = (string)y.Element("abstract"),
                        Bio = (string)y.Element("Bio")
                    }).ToList(),
                    program = x.Elements("Program").Select(y => new {
                        id = (string)y.Attribute("id"),
                        nome = (string)y.Descendants("nome").FirstOrDefault(),
                        sala = (string)y.Descendants("sala").FirstOrDefault(),
                        hora_inicio = (string)y.Descendants("hora_inicio").FirstOrDefault(),
                        hora_fim = (string)y.Descendants("hora_fim").FirstOrDefault(),
                        desc = (string)y.Descendants("desc").FirstOrDefault(),
                        orador = (string)y.Descendants("orador").FirstOrDefault()
                    }).ToList(),
                    contacts = x.Elements("Contacts").Select(y => new {
                        email = (string)y.Attribute("Email"),
                        pagWeb = (string)y.Descendants("PagWeb").FirstOrDefault(),
                        facebook = (string)y.Descendants("Facebook").FirstOrDefault()
                    }).FirstOrDefault(),
                    venue = x.Elements("Venue").Select(y => new {
                        latitude = (string)y.Attribute("Latitude"),
                        longitude = (string)y.Descendants("Longitude").FirstOrDefault(),
                        label = (string)y.Descendants("Label").FirstOrDefault(),
                        address = (string)y.Descendants("Address").FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
