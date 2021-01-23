    public class PurchaseOrder
    {
        [XmlElement("Item")]
        public List<Item> Items;
    }
    public class Item
    {
        public string ItemID;
        public decimal ItemPrice;
    }
