    public class root
    {
        public Items items { get; set; }
    }
    
    public class Items
    {
        public int averageItemLevel { get; set; }
        public int averageItemLevelEquipped { get; set; }
        public Item head {get;set;}
        public Item chest {get;set;}
        public Item feet {get;set;}
        public Item hands {get;set;}
    }
