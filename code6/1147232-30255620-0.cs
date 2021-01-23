    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Sample sample = new Sample(){
                    Something = "1234512345112345",
                    Parameters = new List<Parameter>(){
                        new Parameter(){
                            Name = new List<string>(){"Value", "Value"}
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Sample));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, sample);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Sample));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Sample newSample = (Sample)xs.Deserialize(reader);
            }
        }
        [XmlRoot("Sample")]
        public class Sample
        {
            [XmlElement("Something")]
            public string Something { get; set; }
            [XmlElement("Parameters")]
            public List<Parameter> Parameters { get; set; }
        }
        [XmlRoot("Parameters")]
        public class Parameter
        {
            [XmlElement("Name")]
            public List<string> Name { get; set; }
        }
    }
    ​
