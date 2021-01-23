    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            [XmlRoot(ElementName = "user")]
            public class User
            {
                [XmlElement(ElementName = "name")]
                public string Name { get; set; }
                [XmlElement(ElementName = "motto")]
                public string Motto { get; set; }
                [XmlAttribute(AttributeName = "id")]
                public string Id { get; set; }
            }
    
            [XmlRoot(ElementName = "smallusers")]
            public class Smallusers
            {
                [XmlElement(ElementName = "user")]
                public List<User> User { get; set; }
            }
    
            [XmlRoot(ElementName = "bigusers")]
            public class Bigusers
            {
                [XmlElement(ElementName = "user")]
                public User User { get; set; }
            }
    
            [XmlRoot(ElementName = "DataRoot")]
            public class DataRoot
            {
                [XmlElement(ElementName = "smallusers")]
                public Smallusers Smallusers { get; set; }
                [XmlElement(ElementName = "bigusers")]
                public Bigusers Bigusers { get; set; }
            }
    
    
            static void Main(string[] args)
            {
                string testXMLData = @"<DataRoot><smallusers><user id=""1""><name>John</name><motto>I am john, who are you?</motto></user><user id=""2""><name>Peter</name><motto>Hello everyone!</motto></user></smallusers><bigusers><user id=""3""><name>Barry</name><motto>Earth is awesome</motto></user></bigusers></DataRoot>";
                
                var fileXmlData = File.ReadAllText(@"C:\XMLFile.xml");
                var deserializedObject = DeserializeFromXML(fileXmlData);
                var serializedToXML = SerializeToXml(deserializedObject);
    
                Console.WriteLine(serializedToXML);
                Console.ReadKey();
            }
    
            public static string SerializeToXml(DataRoot DataObject)
            {
                var xsSubmit = new XmlSerializer(typeof(DataRoot));
    
                using (var sw = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(sw))
                    {
                        xsSubmit.Serialize(writer, DataObject);
                        var data = sw.ToString();
                        writer.Flush();
                        writer.Close();
                        sw.Flush();
                        sw.Close();
                        return data;
                    }
                }
            }
    
            public static DataRoot DeserializeFromXML(string xml)
            {
                var xsExpirations = new XmlSerializer(typeof(DataRoot));
                DataRoot rootDataObj = null;
                using (TextReader reader = new StringReader(xml))
                {
                    rootDataObj = (DataRoot)xsExpirations.Deserialize(reader);
                    reader.Close();
                }
                return rootDataObj;
            }
        }
    }
