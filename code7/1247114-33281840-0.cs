    string servResp = await response.Content.ReadAsStringAsync();
                StringReader stringReader = new StringReader(servResp);
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(GoogleAPI.GeocodeResponse));
                    geoCodeResponse = ((GoogleAPI.GeocodeResponse)(serializer.Deserialize(XmlReader.Create(stringReader))));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
