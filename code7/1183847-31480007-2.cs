    public class ShopItems
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public string Image { get; set; }
    }
