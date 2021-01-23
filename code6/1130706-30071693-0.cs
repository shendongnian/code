        var client = new WebClient();
        var metadata = client.DownloadString(metadataUri);
        var model = CreateModel(metadata);
        var schema = CreateSchema(metadata);
        private static IEdmModel CreateModel(string metadata)
        {
            using (var reader = new StringReader(metadata))
            using (var xmlReader = XmlReader.Create(reader))
            {
                return EdmxReader.Parse(xmlReader);
            }
        }
        private static Schema.Schema CreateSchema(string metadata)
        {
            using (var reader = new StringReader(metadata))
            using (var xmlReader = XmlReader.Create(reader))
            {
                var root = XElement.Load(xmlReader);
                return SchemaBuilder.GetSchema(root);
            }
        }
