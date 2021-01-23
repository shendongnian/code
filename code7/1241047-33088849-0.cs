            JObject obj;
            // Load the JObject directly from a file
            using (var streamReader = File.OpenText(fileName))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                obj = JObject.Load(jsonReader);
            }
            // Rename all properties with primitive values (string, number, boolean, null) to begin with "@"
            foreach (var o in obj.Descendants().OfType<JObject>())
                foreach (var property in o.Properties().Where((p => p.Value is JValue && !p.Name.StartsWith("@"))).ToList())
                    property.Replace(new JProperty("@" + property.Name, property.Value));
            // Convert to XmlDocument
            XmlDocument doc;
            using (var reader = obj.CreateReader())
            {
                doc = (XmlDocument)JsonExtensions.DeserializeXmlNode(reader);
            }
