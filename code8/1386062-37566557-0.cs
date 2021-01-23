        //try this 
        public static XElement SerializeRoot(IEnumerable<root> objRoot)
        {
            XElement serializedRoot = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (TextWriter StreamWriter = new StreamWriter(memoryStream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<root>));
                    xmlSerializer.Serialize(StreamWriter, objRoot);
                    serializedRoot = XElement.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
                }
            }
            return serializedRoot;
        }
