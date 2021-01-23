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
                InsertSensorType insertSensorType = new InsertSensorType() {
                    metadata = new Metadata() {
                        insertSensorTypeMetadata = new InsertSensorTypeMetadata() {
                            InsertionMetadata = new List<InsertionMetadataType>() {
                                new ObservationType() { value = "Value1"},
                                new ObservationType() { value = "Value2"},
                                new FeatureOfInterestType() { value = "Value3"},
                                new FeatureOfInterestType() { value = "Value4"}
                            }
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(InsertSensorType));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("swes","http://www.opengis.net/swes/2.0");
                ns.Add("sos","http://www.opengis.net/sos/2.0");
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, insertSensorType, ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(InsertSensorType));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                InsertSensorType newInsertSensorType = (InsertSensorType)xs.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "InsertSensor")]
        public class InsertSensorType
        {
            [XmlElement("metadata")]
            public Metadata metadata { get; set; }
        }
        [XmlRoot("metadata", Namespace = "http://www.opengis.net/swes/2.0")]
        public class Metadata
        {
            [XmlElement("SosInsertionMetadata")]
            public InsertSensorTypeMetadata insertSensorTypeMetadata { get; set; }
        }
        [XmlRoot("SosInsertionMetadata", Namespace = "http://www.opengis.net/sos/2.0")]
        public class InsertSensorTypeMetadata
        {
             [XmlElement()]
             public List<InsertionMetadataType> InsertionMetadata { get; set; }
        }
        [XmlInclude(typeof(ObservationType))]
        [XmlInclude(typeof(FeatureOfInterestType))]
        [Serializable]
        [XmlRoot(Namespace = "http://www.opengis.net/sos/2.0")]
        public class InsertionMetadataType
        {
            public string value { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "observationType", Namespace = "http://www.opengis.net/sos/2.0")]
        public class ObservationType : InsertionMetadataType
        {
        }
        [Serializable]
        [XmlRoot(ElementName = "featureOfInterestType", Namespace = "http://www.opengis.net/sos/2.0")]
        public class FeatureOfInterestType : InsertionMetadataType
        {
     
        }
    }
    ​
