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
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "WateringZone")
                    {
                        reader.ReadToFollowing("WateringZone");
                    }
                    if (!reader.EOF)
                    {
                        XElement wateringZone = (XElement)XElement.ReadFrom(reader);
                        WateringZone newZone = new WateringZone();
                        WateringZone.wateringZones.Add(newZone);
                        newZone.enabled = (Boolean)wateringZone.Element("Enabled");
                        newZone.name = (string)wateringZone.Element("Name");
                        newZone.relay = (int)wateringZone.Element("Relay");
                        newZone.monday = (Boolean)wateringZone.Element("Monday");
                        newZone.tuesday = (Boolean)wateringZone.Element("Tuesday");
                        newZone.wednesday = (Boolean)wateringZone.Element("Wednesday");
                        newZone.thursday = (Boolean)wateringZone.Element("Thursday");
                        newZone.friday = (Boolean)wateringZone.Element("Friday");
                        newZone.saturday = (Boolean)wateringZone.Element("Saturday");
                        newZone.sunday = (Boolean)wateringZone.Element("Sunday");
                        newZone.wateringTurns = wateringZone.Descendants("WateringTurn").Select(x => new WateringTurn() {
                            enabled = (Boolean)x.Element("Enabled"),
                            name = (string)x.Element("Name"),
                            minutes = (int)x.Element("Minutes")
                        }).ToList();
                    }
                }
            }
        }
        public class WateringZone
        {
            public static List<WateringZone> wateringZones = new List<WateringZone>();
            public Boolean enabled { get;set;}
            public string name { get;set;}
            public int relay { get;set;}
            public Boolean monday { get;set;}
            public Boolean wednesday { get; set;}
            public Boolean thursday { get; set;}
            public Boolean tuesday { get; set;}
            public Boolean friday { get; set;}
            public Boolean saturday { get; set;}
            public Boolean sunday { get; set;}
            public List<WateringTurn> wateringTurns { get; set; }
     
        }
        public class WateringTurn
        {
             public Boolean enabled {get;set;}
             public string name { get;set;}
             public int minutes { get; set; }
        }
    }
