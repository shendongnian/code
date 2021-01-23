    class clsDataStruct
    {
        public class ItemType
        {
            public string Name { get; set; }
        }
        public class Item
        {
            public string Name { get; set; }
            public ItemType Type { get; set; }
            public int Cost { get; set; }
            public int Prize { get; set; }
        }
        public class BillByItem
        {
            public DateTime DateSold { get; set; }
            public Item Item { get; set; }
        }
    }
