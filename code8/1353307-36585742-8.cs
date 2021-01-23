    class Program
    {
        static void Main(string[] args)
        {
            string strXML = File.ReadAllText("xml.xml");
            byte[] bufXML = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufXML);
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Container));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Container deserializedXML = (Container)serializer.Deserialize(reader);
                }// put a break point here and mouse-over deserializedXML ….
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
