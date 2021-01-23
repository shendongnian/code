    public class Item
    {
        public Item()
        {
            RelatedItems = new List<Item>();
        }
        public int ItemId { get; set; }
        public int? ParentItemId { get; set; }
        public Item ParentItem{ get; set; }
        public List<Item> RelatedItems { get; set; }
    }
