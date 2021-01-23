    public class Customer<T> where T : IContactInfo
    {
        public string Name { get; }
        public T ContactInfo { get; }
    }
    
    public interface IContactInfo
    {  }
    
    public class GoldContactInfo : IContactInfo
    {
        public string Address { get; }
    }
    
    public class SilverContactInfo : IContactInfo
    {
        public string Telephone { get; }
    }
    public class GoldCustomer : Customer<GoldContactInfo>
    {
         // Here does the GoldCustomer have a GoldContactInfo
    }
    public class SilverCustomer : Customer<SilverContactInfo>
    {
         // Here does the SilverCustomer have a SilverContactInfo
    }
