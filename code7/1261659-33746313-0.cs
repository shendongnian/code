        public class Configuration
        {
            [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
            public List<Tuple<int, int, int>> MyThreeTuple { get; set; }
        }
