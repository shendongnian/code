            try
            {
                Availability deserializedXML = new Availability();
                // Deserialize to object
                XmlSerializer serializer = new XmlSerializer(typeof(Availability));
                using (FileStream stream = File.OpenRead(@"xml.xml"))
                {
                    deserializedXML = (Availability)serializer.Deserialize(stream);
                } // Put a break-point here, then mouse-over deserializedXML
            }
            catch (Exception)
            {
                throw;
            }
