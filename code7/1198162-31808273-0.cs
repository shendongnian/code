    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                SubsonicResponse subsonicResponse = new SubsonicResponse()
                {
                    status = "ok",
                    version = "1.10.1",
                    artists = new Artists()
                    {
                        ignoredArticles = "The El La Los Las Le Les",
                        indexes = new List<Index>() {
                            new Index() {
                                name = "A", artists = new List<Artist>() {
                                    new Artist() { id = 5449, name = "A-Ha", converArt = "ar-5449", albumCount = 4},
                                    new Artist() { id = 5221, name = "ABBA", converArt = "ar-5421", albumCount = 6},
                                    new Artist() { id = 5432, name = "AC/DC", converArt = "ar-5432", albumCount = 15},
                                    new Artist() { id = 6633, name = "Aaron Neville", converArt = "ar-5633", albumCount = 1}
                                }
                            },
                            new Index() {
                                name = "B", artists = new List<Artist>() {
                                    new Artist() { id = 5950, name = "Bob Marley", converArt = "ar-5950", albumCount = 8},
                                    new Artist() { id = 5957, name = "Bruce Dickinson", converArt = "ar-5957", albumCount = 2}
                                }
                            }
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(SubsonicResponse));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "http://subsonic.org/restapi");
                serializer.Serialize(writer, subsonicResponse, ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(SubsonicResponse));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                SubsonicResponse newSResponse = (SubsonicResponse)xs.Deserialize(reader);
                
            }
        }
        [XmlRoot("subsonic-response", Namespace = "http://subsonic.org/restapi")]
        public class SubsonicResponse
        {
            [XmlAttribute("status")]
            public string status { get; set; }
            [XmlAttribute("version")]
            public string version { get; set; }
            [XmlElement("artists")]
            public Artists artists { get; set; }
        }
        [XmlRoot(ElementName = "artists")]
        public class Artists
        {
            [XmlAttribute("ignoredArticles")]
            public string ignoredArticles { get; set; }
            [XmlElement("index")]
            public List<Index> indexes { get; set; }
        }
        [XmlRoot("index")]
        public class Index
        {
            [XmlAttribute("name")]
            public string  name { get; set; }
            [XmlElement("artist")]
            public List<Artist> artists { get; set; }
        }
        [XmlRoot("artist")]
        public class Artist
        {
           [XmlAttribute("id")]
            public int  id { get; set; }
           [XmlAttribute("name")]
            public string  name { get; set; }
           [XmlAttribute("converArt")]
            public string  converArt { get; set; }
           [XmlAttribute("albumCount")]
            public int  albumCount { get; set; }
        }
    }
    ​
