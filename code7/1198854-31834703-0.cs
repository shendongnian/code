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
                LeagueCollection leagueCollection = new LeagueCollection() {
                    leagues = new Leagues() {
                        League = new List<League>() {
                           new League() {
                              Id = 1,
                              Name = "English Premier League",
                              Country = "England",
                              Historical_Data = "Yes",
                              Fixtures = "Yes",
                              Livescore = "Yes",
                              NumberOfMatches = 5700,
                              LatestMatch = DateTime.Parse( "2015-05-24T16:00:00+00:00")
                        },
                            new League() {
                                Id = 2,
                                Name = "English League Championship",
                                Country = "England",
                                Historical_Data = "Yes",
                                Fixtures = "Yes",
                                Livescore = "Yes",
                                NumberOfMatches = 5700,
                                LatestMatch = DateTime.Parse("2015-05-24T16:00:00+00:00")
                            }
                        }
                    },
                    AccountInformation = "Confidential info"
                };
                XmlSerializer serializer = new XmlSerializer(typeof(LeagueCollection));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, leagueCollection);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer deserializer = new XmlSerializer(typeof(LeagueCollection));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                LeagueCollection XmlData = (LeagueCollection)deserializer.Deserialize(reader);
                reader.Close();
        
            }
        }
        [XmlRoot(ElementName = "LeaugeCollection")]
        public class LeagueCollection
        {
            [XmlElement("Leagues")]
            public Leagues leagues { get; set; }
            [XmlElement(ElementName = "AccountInformation")]
            public string AccountInformation { get; set; }
        }
        [XmlRoot("Leagues")]
        public class Leagues
        {
            [XmlElement("League")]
            public List<League> League { get; set; }
        }
        [XmlRoot("League")]
        public class League
        {
            [XmlElement(ElementName = "Id")]
            public int Id { get; set; }
            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "Country")]
            public string Country { get; set; }
            [XmlElement(ElementName = "Historical_Data")]
            public string Historical_Data { get; set; }
            [XmlElement(ElementName = "Fixtures")]
            public string Fixtures { get; set; }
            [XmlElement(ElementName = "LiveScore")]
            public string Livescore { get; set; }
            [XmlElement(ElementName = "NumberOfMatches")]
            public int NumberOfMatches { get; set; }
            [XmlElement(ElementName = "LatestMatch")]
            public DateTime LatestMatch { get; set; }
        }
    }
    ​
    ​
