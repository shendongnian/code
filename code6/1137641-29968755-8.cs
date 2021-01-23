    public class Product: Items
    {      
        public DateTime ProductDateCreated { get; set; }
        //....
    }
    public class Advert: Items
    {
        public int AdvertView { get; set; }
    }
    public class Items //Advert and Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
