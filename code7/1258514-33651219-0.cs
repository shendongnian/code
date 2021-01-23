    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ShopAddress> Addresses { get; set; } 
    }
    public class ShopAddress
    {
        public int Id { get; set; }
        public virtual Address Address { get; set; }
        public AddressType AddressType { get; set; }
        
    }
    public enum AddressType
    {
        Postal,
        Physical
    }
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
    }
