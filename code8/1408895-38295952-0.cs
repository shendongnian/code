    public class MyObject : DynamicObject
    {
        [JsonProperty("MyList")]
        public List<MyProperty> MyList { get; set; }
    }
