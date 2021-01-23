            try
            {
                XmlSerializer DeserializerPlaces = new XmlSerializer(typeof(DeviceState));
                string html = string.Empty;
                string url = @"https://<Your URL>";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    DeviceState dezerializedXML = (DeviceState)DeserializerPlaces.Deserialize(reader);
                    //html = reader.ReadToEnd();
                }
                //Console.WriteLine(html);
            }
            catch (System.Exception)
            {
                throw;
            }
