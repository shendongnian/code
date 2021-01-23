    public class Address
    {
         public string Street { get; set; }
         public Country Country { get; set; }
    }
    
    var addr = new Address { Street = "Sesamestreet", Country = Country.GB };
