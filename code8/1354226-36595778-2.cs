            string strXML = File.ReadAllText("xml.xml");
            byte[] bufXML = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufXML);
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Prestashop));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Prestashop deserializedXML = (Prestashop)serializer.Deserialize(reader);
                }// put a break point here and mouse-over Label1Text and Label2Text ….
            }
            catch (Exception ex)
            {
                throw;
            }
