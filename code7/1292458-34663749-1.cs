        public class MyClass
        {
            // Indicate the property not to apply any type handling
            [JsonProperty(TypeNameHandling=TypeNameHandling.None)]
            public IList<string> Values { get; set; }
            public string Name { get; set; }
        }
