    [JsonConverter(typeof(HasCommonFieldsConverter<Container1>))]
    public class Container1 : IHasCommonFields
    {
        [JsonIgnore]
        public CommonFields Common { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "ProductId")]
        public int ProductId { get; set; }
    }
    [JsonConverter(typeof(HasCommonFieldsConverter<Container2>))]
    public class Container2 : IHasCommonFields
    {
        [JsonIgnore]
        public CommonFields Common { get; set; }
        [JsonProperty(PropertyName = "Group")]
        public Guid Group { get; set; }
    }
