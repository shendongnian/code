    public static class JsonExtensions
    {
        public static JToken ParseUppercase(string json)
        {
            using (var textReader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(textReader))
            {
                return jsonReader.ParseUppercase();
            }
        }
        public static JToken ParseUppercase(this JsonReader reader)
        {
            return reader.Parse(n => n.ToUpperInvariant());
        }
        public static JToken Parse(this JsonReader reader, Func<string, string> nameMap)
        {
            JToken token;
            using (var writer = new RenamingJTokenWriter(nameMap))
            {
                writer.WriteToken(reader);
                token = writer.Token;
            }
            return token;
        }
    }
    class RenamingJTokenWriter : JTokenWriter
    {
        readonly Func<string, string> nameMap;
        public RenamingJTokenWriter(Func<string, string> nameMap)
            : base()
        {
            if (nameMap == null)
                throw new ArgumentNullException();
            this.nameMap = nameMap;
        }
        public override void WritePropertyName(string name)
        {
            base.WritePropertyName(nameMap(name));
        }
        public override void WritePropertyName(string name, bool escape)
        {
            base.WritePropertyName(nameMap(name), escape);
        }
    }
