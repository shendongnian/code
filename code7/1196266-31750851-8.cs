        public class MyClass
        {
            [JsonConverter(typeof(NullToDefaultConverter<Guid>))]
            public Guid Property { get; set; }
        }
 
