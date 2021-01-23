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
            static void Main(string[] args)
            {
                CreatureCollection creatures = new CreatureCollection() { creatures = new List<string>() { "", "", "" } };
                StringBuilder builder = new StringBuilder();
                StringWriter writer = new StringWriter(builder);
                XmlWriter xWriter = XmlWriter.Create(writer);
                creatures.WriteXml(xWriter);
            }
        }
        public class CreatureCollection : List<string>, IXmlSerializable
        {
            public List<string> creatures { get; set; }
            public System.Xml.Schema.XmlSchema GetSchema() { return null; }
            public void ReadXml(XmlReader reader)
            {
            }
            public void WriteXml(XmlWriter writer)
            {
                Something something = new Something() { creatures = new List<string>() };
                something.creatures.AddRange(creatures);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Something));
                xmlSerializer.Serialize(writer, something);
            }
        }
        [XmlRoot("Something")]
        public class Something
        {
            [XmlElement("Creature")]
            public List<string> creatures { get; set; }
        }
    }
    ​
