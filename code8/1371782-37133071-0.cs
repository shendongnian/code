      public static object ObjectFromXMLString(Type typeOfObject, string xmlFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeOfObject);
            StringReader rdr = new StringReader(xmlFile);
            return serializer.Deserialize(rdr);
        }
