        public void WriteXml(string fileName)
        {
            var people = new People { Results = GetPeopleInChunks().SelectMany(list => list) };
            using (var writer = XmlWriter.Create(fileName))
            {
                new XmlSerializer(typeof(People)).Serialize(writer, people);
            }
        }
