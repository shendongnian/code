            string strXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                <lijst>
                                    <lijst_item>
                                        <id>1</id>
                                        <naam>NAME REDACTED</naam>
                                        <archived>false</archived>
                                    </lijst_item>
                                    <lijst_item>
                                        <id>2</id>
                                        <naam>NAME REDACTED</naam>
                                        <archived>false</archived>
                                    </lijst_item>
                                    <lijst_item>
                                        <id>3</id>
                                        <naam>NAME REDACTED</naam>
                                        <archived>false</archived>
                                    </lijst_item>
                                </lijst>";
            byte[] bufXML = ASCIIEncoding.UTF8.GetBytes(strXML);
            MemoryStream ms1 = new MemoryStream(bufXML);
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Lijst));
            try
            {
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Lijst deserializedXML = (Lijst)serializer.Deserialize(reader);
                }// put a break point here and mouse-over Label1Text and Label2Text ….
            }
            catch (Exception ex)
            {
                throw;
            }
