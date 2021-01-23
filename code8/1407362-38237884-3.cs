    public class Parent<T>
    {
        public string ParentName { get; set; }
        [JsonConverter(typeof(InterfaceToConcreteGenericJsonConverter), new object[] { typeof(Example<>) })]
        public IExample<T> ExampleItem { get; set; }
    }
