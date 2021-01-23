    class Parent
    {
        public Parent(IEnumerable<Item> items)
        {
            this.Items = items;
        }
        [JsonConstructor]
        private Parent()
        {
        }
        [JsonProperty("itemdetails")]
        public IEnumerable<Item> Items { get; private set; }
    }
