    public class BaseClass
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Time")]
        public long Time { get; set; }
    }
    public class Container1 : BaseClass
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "ProductId")]
        public int ProductId { get; set; }
    }
    public class Container2 : BaseClass
    {
        [JsonProperty(PropertyName = "Group")]
        public Guid Group { get; set; }
    }
