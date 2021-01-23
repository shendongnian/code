    public class Folder
    {
        public Folder() { this.Folders = new List<Folder>(); }
        [JsonProperty("FOLDER_NAME")]
        public string FolderName { get; set; }
        public List<Folder> Folders { get; set; }
    }
    public class FolderListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Folder>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Format of a folder list is
            // Object with name of folder
            // Array of child folders as a folderlist.
            var folders = (existingValue as List<Folder> ?? new List<Folder>());
            var array = JArray.Load(reader);
            foreach (var token in array)
            {
                switch (token.Type)
                {
                    case JTokenType.Object:
                        folders.Add(token.ToObject<Folder>(serializer));
                        break;
                    case JTokenType.Array:
                        {
                            var folder = folders.Last(); // Throws an exception if none read yet.
                            (folder.Folders = (folder.Folders ?? new List<Folder>())).AddRange(token.ToObject<List<Folder>>(serializer));
                        }
                        break;
                    default:
                        throw new JsonSerializationException("unknown token " + token.ToString());
                }
            }
            return folders;
        }
        public override bool CanWrite { get { return false; }}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
