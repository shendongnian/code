            string strXML = File.ReadAllText("xml.xml");
            byte[] bufXML = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufXML);
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Neworder));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Neworder deserializedXML = (Neworder)serializer.Deserialize(reader);
                }// put a break point here and mouse-over deserializedXML….
            }
            catch (Exception ex)
            {
                throw;
            }
