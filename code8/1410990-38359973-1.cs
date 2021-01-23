    [JsonConverter(typeof(ActionConverter))]
    public class Action
    {
        readonly static Dictionary<Type, System.Type> typeToSystemType;
        readonly static Dictionary<System.Type, Type> systemTypeToType;
        static Action()
        {
            typeToSystemType = new Dictionary<Type, System.Type>
            {
                { Type.Open, typeof(OpenActionResult) },
            };
            systemTypeToType = typeToSystemType.ToDictionary(p => p.Value, p => p.Key);
        }
        public static Type SystemTypeToType(System.Type systemType)
        {
            return systemTypeToType[systemType];
        }
        public static System.Type TypeToSystemType(Type type)
        {
            return typeToSystemType[type];
        }
        public enum Type
        {
            Open,
            Close,
            Remove,
            Delete,
            Reverse,
            Alert,
            ScaleInOut,
            Nothing
        }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("active")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool Active { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(ActionTypeConverter))]
        public Type ActionType { get; set; }
        [JsonProperty("result")]
        public ActionResult Result { get; set; }
    }
    class ActionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var obj = JObject.Load(reader);
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
            var action = existingValue as Action ?? (Action)contract.DefaultCreator();
            // Remove the Result property for manual deserialization
            var result = obj.GetValue("Result", StringComparison.OrdinalIgnoreCase).RemoveFromLowestPossibleParent();
            // Populate the remaining properties.
            using (var subReader = obj.CreateReader())
            {
                serializer.Populate(subReader, action);
            }
            // Process the Result property
            if (result != null)
                action.Result = (ActionResult)result.ToObject(Action.TypeToSystemType(action.ActionType));
            return action;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class JsonExtensions
    {
        public static JToken RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                return null;
            var contained = node.AncestorsAndSelf().Where(t => t.Parent is JContainer && t.Parent.Type != JTokenType.Property).FirstOrDefault();
            if (contained != null)
                contained.Remove();
            // Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
            if (node.Parent is JProperty)
                ((JProperty)node.Parent).Value = null;
            return node;
        }
    }
