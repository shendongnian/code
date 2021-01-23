    public class RootObject
    {
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Objects)]
        public object Data { get; set; }
    }
