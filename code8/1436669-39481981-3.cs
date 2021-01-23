    class Progress
    {
        [JsonConverter(typeof(StackConverter))]
        public Stack<Item> Items { get; set; }
        public Progress()
        {
            Items = new Stack<Item>();
        }
    }
