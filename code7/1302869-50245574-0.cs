      public static T DeserializeObject(string xml, string Namespace)
      {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T), Namespace);
            //**** I don't think you need this block of code *********
            //MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(xml));
            //XmlReaderSettings settings = new XmlReaderSettings();
            // allow entity parsing but do so more safely
            //settings.DtdProcessing = DtdProcessing.Ignore;
            //settings.XmlResolver = null;
            //*********************************************
            XmlTextReader reader = new XmlTextReader(xml)
            {
                XmlResolver = null
            };
            return serializer.Deserialize(reader) as T;
      }
