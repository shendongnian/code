    [Serializable]
    public class Group
    {
        [XmlArrayItem(ElementName = "SELLER", Type = typeof(Seller))]
        public Seller[] Sellers { get; set; }
    }
