    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace openlpimport
    {
        class Program
        {
            const string FILENAME1 = @"c:\temp\test.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            const string FILENAME3 = @"c:\temp\test3.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME1);
                XElement xmlSong = (XElement)doc.FirstNode;
                XNamespace ns = xmlSong.Name.Namespace;
                Song song = new Song() {
                    title = doc.Descendants(ns + "title").FirstOrDefault().Value,
                    author = doc.Descendants(ns + "author").FirstOrDefault().Value,
                    copyright = doc.Descendants(ns + "copyright").FirstOrDefault().Value,
                    ccli = doc.Descendants(ns + "ccliNo").FirstOrDefault().Value,
                    hymnal = doc.Descendants(ns + "songbook").Attributes("name").FirstOrDefault().Value,
                    notes = doc.Descendants(ns + "comment").FirstOrDefault().Value,
                    verseList = new List<Verse>() { 
                        new Verse() {
                           lyricList =  doc.Descendants(ns + "verse").Select(x => new Lyric() {
                                    verseName = x.Attribute("name").Value,
                                    verseLyric = x.Element(ns + "lines").Value
                           }).ToList()
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Song));
                StreamWriter writer = new StreamWriter(FILENAME2);
                serializer.Serialize(writer, song);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                string identification = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Song></Song>";
                XDocument newDoc = XDocument.Parse(identification);
                XElement song2 = (XElement)newDoc.FirstNode;
                song2.Add(new object[] {
                    new XElement("br", song.title),
                    new XElement("br", song.author),
                    new XElement("br", song.copyright),
                    new XElement("br", song.ccli),
                    new XElement("br", song.hymnal),
                    new XElement("br", song.notes),
                    new XElement("br", song.playorder),
                    song.verseList[0].lyricList.Select(x => new object[] {
                        new XElement("br", x.verseName),
                        new XElement("br", x.verseLyric)
                    }).ToList()
                });
                newDoc.Save(FILENAME3);
            }
        }
        [XmlRoot("Song")]
        public class Song
        {
            [XmlElement("Title")]
            public string title { get; set; }
            [XmlElement("Author")]
            public string author { get; set; }
            [XmlElement("Copyright")]
            public string copyright { get; set; }
            [XmlElement("Ccli")]
            public string ccli { get; set; }
            [XmlElement("Hymnal")]
            public string hymnal { get; set; }
            [XmlElement("Notes")]
            public string notes { get; set; }
            [XmlElement("PlayOrder")]
            public string playorder { get; set; }
            [XmlElement("Verse")]
            public List<Verse> verseList { get; set; }
            public Song()
            {
                verseList = new List<Verse>();
            }
        }
        [XmlRoot("Verse")]
        public class Verse
        {
            [XmlElement("LyricList")]
            public List<Lyric> lyricList { get; set; }
            public Verse()
            {
                lyricList = new List<Lyric>();
            }
        }
        [XmlRoot("Lyric")]
        public class Lyric
        {
            [XmlElement("VerseName")]
            public string verseName { get; set; }
            [XmlElement("VerseLyric")]
            public string verseLyric { get; set; }
            public Lyric()
            {
                verseLyric = "N/A";
            }
        }
    }
    ​
    ​
