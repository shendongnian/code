    public class Customer
    {
        public string Name { get; }
        public ContactInfo ContactInfo { get; }
    }
    public abstract class ContactInfo
    {
        public virtual string Address => "";
        public virtual string Telephone => "";
    }
    public class GoldContactInfo : ContactInfo
    {
        public override string Address { get; }
    }
    public class SilverContactInfo : ContactInfo
    {
        public override string Telephone { get; }
    }
