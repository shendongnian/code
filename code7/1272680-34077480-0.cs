    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace openlpimport
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
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
                           
            }
        }
        public class Song
        {
            public string title { get; set; }
            public string author { get; set; }
            public string copyright { get; set; }
            public string ccli { get; set; }
            public string hymnal { get; set; }
            public string notes { get; set; }
            public string playorder { get; set; }
            public List<Verse> verseList { get; set; }
            public Song()
            {
                verseList = new List<Verse>();
            }
        }
        public class Verse
        {
            public List<Lyric> lyricList { get; set; }
            public Verse()
            {
                lyricList = new List<Lyric>();
            }
        }
        public class Lyric
        {
            public string verseName { get; set; }
            public string verseLyric { get; set; }
            public Lyric()
            {
                verseLyric = "N/A";
            }
        }
    }
    ​
