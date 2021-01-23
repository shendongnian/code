    public class Parent<T>
    {
        public string ParentName { get; set; }
        [JsonProperty(ItemConverterType = typeof(InterfaceToConcreteGenericJsonConverter), ItemConverterParameters = new object[] { typeof(Example<>) })]
        public List<IExample<T>> ExampleList { get; set; }
    }
