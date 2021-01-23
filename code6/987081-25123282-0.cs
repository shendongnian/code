    public class RequestConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Request));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // On deserialization, the JSON has an entity identifier (GUID)
            // so use it to retrieve the actual object from the database.
            JToken token = JToken.Load(reader);
            Request req = new Request();
            req.Entity = RetrieveFromDatabase(token["entity"].ToString());
            return req;
        }
        private EntityObject RetrieveFromDatabase(string entityIdentifier)
        {
            // Implement this method to retrieve the actual EntityObject from the DB.
            // (Return null if the object is not found.)
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // On serialization, write out just the entity object properties
            Request req = (Request)value;
            JObject obj = new JObject();
            obj.Add("entity", JToken.FromObject(req.Entity));
            obj.WriteTo(writer);
        }
    }
