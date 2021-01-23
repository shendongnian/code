            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition%20from%20weather.forecast%20where%20woeid%20in%20%28select%20woeid%20from%20geo.places%281%29%20where%20text%3D%22Cape%20Town%22%29&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                string XMLxmlDocument = xmlDocument.InnerXml.ToString();
                byte[] BUFXML = ASCIIEncoding.UTF8.GetBytes(XMLxmlDocument);
                MemoryStream ms1 = new MemoryStream(BUFXML);
                XmlSerializer DeserializerPlaces = new XmlSerializer(typeof(Query));//, new XmlRootAttribute("Query"));
                using (XmlReader reader = new XmlTextReader(ms1))
                {
                    Query dezerializedXML = (Query)DeserializerPlaces.Deserialize(reader);
                    string temp = dezerializedXML.Results.Channel.Item.Condition.Temp;
                    string text = dezerializedXML.Results.Channel.Item.Condition.Text;
                }// Put a break-point here, then mouse-over temp and text, you should have you values (dezerializedXML contains the entire object)
            }
            catch (System.Exception)
            {
                throw;
            }
