    class Parent
    {
        public Parent(IEnumerable<Item> items)
        {
            this.Items = items;
        }
        [JsonProperty("itemdetails")]
        public IEnumerable<Item> Items { get; private set; }
    }
