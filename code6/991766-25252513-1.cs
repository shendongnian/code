        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        private static string GetXml<T>(T obj, DataContractSerializer serializer) where T : class 
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    "; // The indentation used in the test string.
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.WriteObject(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        public static string GetXml<T>(T obj) where T : class
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            return GetXml(obj, serializer);
        }
