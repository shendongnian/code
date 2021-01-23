        public void Post(HttpRequestMessage request)
        {
                // Reading data as XML string to log to files - In case message structure is changed
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(request.Content.ReadAsStreamAsync().Result);
                var str = xmlDoc.InnerXml;
                // Convert to model
                var model = XMLHelper.FromXml<trackermessages>(str);
       }
