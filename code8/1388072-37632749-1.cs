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
                Conferencia conferencia = doc.Descendants().Select(x => new Conferencia()
                {
                    Info = x.Elements("info").Select(y => new Info()
                    {
                        localizaçao_imagem = (string)y.Element("loc_img"),
                        info = (string)y.Element("infor")
                    }).FirstOrDefault(),
                    KeynoteSpeakers = new List<Keynote>(
                        x.Descendants("Keynote").Select(y => new Keynote() {
                            id = (string)y.Attribute("id"),
                            foto = (string)y.Element("foto"),
                            nome = (string)y.Element("nome"),
                            organizacao = (string)y.Element("organizacao"),
                            funcao = (string)y.Element("funcao"),
                            abs = (string)y.Element("abstract"),
                            Bio = (string)y.Element("Bio")
                        })
                    ).ToList(),
                    Programmes = new Programme()
                    {
                        Days = x.Descendants("Day").Select(y => new Day()
                        {
                            id = (string)y.Attribute("id"),
                            Blocks = y.Elements("block").Select(z => new Block() {
                                
                                   Nome_Sessao = (string)y.Descendants("nome").FirstOrDefault(),
                                   Sala = (string)y.Descendants("sala").FirstOrDefault(),
                                   Hora_Inicio  =  (string)y.Descendants("hora_inicio").FirstOrDefault() == "" ? new DateTime() : (DateTime)y.Descendants("hora_inicio").FirstOrDefault(),
                                   Hora_Fim = (string)y.Descendants("hora_inicio").FirstOrDefault() == "" ? new DateTime() : (DateTime)y.Descendants("hora_fim").FirstOrDefault(),
                             }).ToList(),
                             
                        }).ToList()
                    },
                    Contacts = x.Elements("Contacts").Select(y => new Contact() {
                            Email = (string)y.Attribute("Email"),
                            Pagina_Web = (string)y.Descendants("PagWeb").FirstOrDefault(),
                            Facebook = (string)y.Descendants("Facebook").FirstOrDefault()
                    }).ToList(),
                    Venue = x.Elements("Venue").Select(y => new Venue() {
                            Latitude =  (string)y.Element("Latitude") == "" ? 0 : (double?)y.Element("Latitude"),
                            Longitude = (string)y.Element("Longitude") == "" ? 0 : (double?)y.Element("Longitude"),
                            Label = (string)y.Descendants("Label").FirstOrDefault(),
                            Adress = (string)y.Descendants("Address").FirstOrDefault()
                    }).FirstOrDefault()
                }).FirstOrDefault();
            }
        }
        public class Conferencia
        {
            public Info Info { get; set; }
            public List<Keynote> KeynoteSpeakers { get; set; }
            public List<Committee> Committees { get; set; }
            public Programme Programmes { get; set; }
            public List<Contact> Contacts { get; set; }
            public Venue Venue { get; set; }
        }
        public class Info
        {
            public string localizaçao_imagem { get; set; }
            public string info { get; set; }
        }
        public class Keynote
        {
            public string id { get; set; }
            public string foto { get; set; }
            public string nome { get; set; }
            public string organizacao { get; set; }
            public string funcao { get; set; }
            public string abs { get; set; }
            public string Bio { get; set; }
        }
        public class Committee
        {
            public string Tipo { get; set; }
            public List<Elemento> Elementos { get; set; }
        }
        public class Elemento
        {
            public string elemento { get; set; }
        }
        public class Programme
        {
            public List<Day> Days { get; set; }
        }
        public class Day
        {
            public string id { get; set; }
            public List<Block> Blocks { get; set; }
        }
        public class Block
        {
            public string Nome_Sessao { get; set; }
            public string Sala { get; set; }
            public DateTime? Hora_Inicio { get; set; }
            public DateTime? Hora_Fim { get; set; }
        }
        public class AcceptedPaper
        {
            public string id { get; set; }
            public List<Paper> Papers { get; set; }
        }
        public class Paper
        {
            public string desc { get; set; }
            public string sala { get; set; }
            public string day { get; set; }
            public string hour { get; set; }
            public List<block> blocks { get; set; }
        }
        public class block
        {
            public string title { get; set; }
            public string orador { get; set; }
        } 
        public class Contact
        {
            public string Email { get; set; }
            public string Pagina_Web { get; set; }
            public string Facebook { get; set; }
        }
        public class Venue
        {
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            public string Label { get; set; }
            public string Adress { get; set; }
        }   
    }
