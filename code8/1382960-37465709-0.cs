        // xmlElement is the column read from DB , consider having an index on the field as well as batching the reads if its too big   
        public static List<History> DeserializeHistory(XElement xmlElement)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<History>));
            using (System.Xml.XmlReader reader = xmlElement.CreateReader())
            {
                return (List<History>)serializer.Deserialize(reader);
            }
            
        }
