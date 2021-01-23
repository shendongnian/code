            try
            {
                string query1 = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address=Donegal%20Town&key=<Your Key>");
                XmlDocument GeocodeResponse = new XmlDocument();
                GeocodeResponse.Load(query1);
                string XMLGeocodeResponse = GeocodeResponse.InnerXml.ToString();
                byte[] BUFGeocodeResponse = ASCIIEncoding.UTF8.GetBytes(XMLGeocodeResponse);
                MemoryStream ms1 = new MemoryStream(BUFGeocodeResponse);
                XmlSerializer DeserializerPlaces = new XmlSerializer(typeof(GeocodeResponse), new XmlRootAttribute("GeocodeResponse"));
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    GeocodeResponse dezerializedXML = (GeocodeResponse)DeserializerPlaces.Deserialize(reader);
                    Location LatLng = dezerializedXML.Result[0].Geometry.Location;
                }// Put a break-point here, then mouse-over LatLng and you should have you values
            }
            catch (System.Exception)
            {
                throw;
            }
