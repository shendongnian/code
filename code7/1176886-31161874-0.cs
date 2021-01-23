    using System;
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfShows));
                StreamReader reader = new StreamReader(@"C:\Raj\Learn\TestConsole\TestConsole\XMLFile1.xml"); //Give path of the file.
                var listOfShows = (ListOfShows)serializer.Deserialize(reader);
                reader.Close();
            }
        }
    
        [Serializable]
        public class ListOfShows
        {
    
            public List<ShowData> list { get; set; }
            public ListOfShows()
            {
                list = new List<ShowData>();
            }
    
            public XDocument generateXMLDocument()
            {
                var xml = new XDocument();
                using (var writer = xml.CreateWriter())
                {
                    var serializer = new XmlSerializer(typeof(ListOfShows));
                    serializer.Serialize(writer, this);
                }
                return xml;
            }
        }
    
        [Serializable]
        public class ShowData
        {
            public ShowData()
            {
            }
            public string UniqueId { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public string Content { get; set; }
        }
    }
