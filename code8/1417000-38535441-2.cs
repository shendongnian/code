        public static StateCountyRecords DeserializeStateCountyData(string xmlString)
        {
            var mySerializer = new XmlSerializer(typeof(StateCountyFile));
            using (var myXmlReader = XmlReader.Create(new StringReader(xmlString)))
            {
                var rslt = (StateCountyFile)mySerializer.Deserialize(myXmlReader);
                return rslt.StateCountyRecords;
            }
        }
