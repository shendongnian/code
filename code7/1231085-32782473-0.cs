    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Collections;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Stream stream = File.Open(FILENAME, FileMode.Open);
                ClassLibrary2.Root root = ClassLibrary2.serialize.Deserialize<ClassLibrary2.Root>(stream);
                stream.Close();
                ClassLibrary2.serialize.Serialize(root, FILENAME);
            }
        }
    }
    namespace ClassLibrary2
    {
        [XmlRoot(ElementName = "ClubRegisterQuick")]
        public class Root
        {
            [XmlElement("Clubs")]
            public Clubs clubs { get; set; }
        }
        public class Clubs
        {
            [XmlElement("Club")]
            public List<Club> clubs { get; set; }
        }
        public class Club
        {
            [XmlElement("Email")]
            public string Email { get; set; }
            [XmlElement("Clubname")]
            public string Clubname { get; set; }
            [XmlElement("Clubphonenumber")]
            public string Clubphonenumber { get; set; }
            [XmlElement("Firstname")]
            public string Firstname { get; set; }
            [XmlElement("Lastname")]
            public string Lastname { get; set; }
            [XmlElement("Town")]
            public string Town { get; set; }
            [XmlElement("Country")]
            public string Country { get; set; }
            [XmlElement("Location")]
            public string Location { get; set; }
            [XmlElement("Currency")]
            public string Currency { get; set; }
            [XmlElement("Password")]
            public string Password { get; set; }
            [XmlElement("Clubtype")]
            public string Clubtype { get; set; }
        }
        public static class serialize
        {
            public static T Deserialize<T>(string path)
            {
                T result;
                using (var stream = File.Open(path, FileMode.Open))
                {
                    result = Deserialize<T>(stream);
                }
                return result;
            }
            public static void Serialize<T>(T root, string path)
            {
                using (var stream = File.Open(path, FileMode.Create))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(stream, root);
                    stream.Flush();
                    stream.Close();
                }
                
            }
            public static T Deserialize<T>(Stream stream)
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stream);
            }
            
        }
    }
    ​
