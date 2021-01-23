    [Serializable]
    public class Items
    {
        [XmlArray("itens")]
        public List<Item> itens { get; set; }
    }
