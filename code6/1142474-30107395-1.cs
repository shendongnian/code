        public static T LoadFromXML<T>(string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = new XmlSerializer(typeof(T)).Deserialize(reader);
                if (result is T)
                {
                    return (T)result;
                }
            }
            return default(T);
        }
        public static string GetXml<T>(T obj)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj);
                return textWriter.ToString();
            }
        }
        public static void Test()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
                <xml>
                  <result>OK</result> 
                <headers>
                  <header>lastname</header> 
                  <header>firstname</header> 
                  <header>Age</header> 
                  </headers>
                <data>
                <datum>
                  <item>Kelly</item> 
                  <item>Grace</item> 
                  <item>33</item> 
                </datum>
                  </data>
                </xml>";
            var response = LoadFromXML<XmlResponse>(xml);
            Debug.WriteLine(GetXml(response));
