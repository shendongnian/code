    public class Shop
    {
        public int Id { get; set; }
        public virtual ICollection<ShopLocation> ShopLocations { get; set; }
    }
    
    public class Location
    {
        public int Id { get; set; }
        public virtual ICollection<ShopLocation> ShopLocations { get; set; }
    }
    
    public class ShopLocation
    {
        public int Id { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual Location Location { get; set; }
    }
