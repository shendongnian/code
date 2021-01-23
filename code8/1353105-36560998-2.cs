    class Program
    {
        static void Main(string[] args)
        {
            string strXML = File.ReadAllText("xml.xml");
            byte[] bufXML = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufXML);
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(ContentTypes));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    ContentTypes deserializedXML = (ContentTypes)serializer.Deserialize(reader);
                }// put a break point here and mouse-over deserializedXML….
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
