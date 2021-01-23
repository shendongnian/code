        public void WriteXml(string fileName)
        {
            var people = new People { Results = GetPeopleInChunks().SelectMany(chunk => chunk) };
            using (var writer = XmlWriter.Create(fileName))
            {
                new XmlSerializer(typeof(People)).Serialize(writer, people);
            }
        }
