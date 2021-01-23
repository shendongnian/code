        public void DeserializeXml(string xml)
        {
            var serializer = new XmlSerializer(typeof(ramowka));
            var buffer = Encoding.UTF8.GetBytes(xml);
            using (var stream = new MemoryStream(buffer))
            {
                var ramowka = (ramowka)serializer.Deserialize(stream);
            }
        }
