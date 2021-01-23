    class ItemList
    {
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public Item[] Items { get; set; }
        public void Load(Stream stream)
        {
            //Insert Code options from above here
            Items = serializer.Deserializer(typeof(Item[])) as Item[];
        }
    }
