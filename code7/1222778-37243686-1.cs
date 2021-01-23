    class Data
    {
        [JsonProperty("$area")]
        public float Area { get; set; }
        [JsonProperty("$color")]
        public Color Color { get; set; }
    }
    class Item
    {
        public string Name { get; set; }
        public Data Data { get; set; }
        public IEnumerable<Item> Children { get; set; }
        internal TreeMapData TMData { get; set; }
    }
