            try
            {
                DeviceState deserializedXML = new DeviceState();
                // Deserialize to object
                XmlSerializer serializer = new XmlSerializer(typeof(DeviceState));
                using (FileStream stream = File.OpenRead(@"xml.xml"))
                {
                    deserializedXML = (DeviceState)serializer.Deserialize(stream);
                    // Now get all your IDs
                    List<string> IDs = (from xml in deserializedXML.Variable select xml.Id).ToList();
                } // Put a break-point here, then mouse-over IDs and you will see all your IDs... deserializedXML contains the entire object if you want anythin else ....
            }
            catch (Exception)
            {
                throw;
            }
