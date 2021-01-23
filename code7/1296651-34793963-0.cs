    public class AddressBase
    {
        public string X { get; set; }
    }
    
    public class FirstSubAddressBase : AddressBase
    {
        public string a { get; set; }
    }
    
    public class SecondSubAddressBase : AddressBase
    {
        public string b { get; set; }
    }
    
    public class NationalAddress : FirstSubAddressBase
    {        
        public string Prop1 { get; set; }
    }
    
    public class InternationalAddress : FirstSubAddressBase
    {        
        public string Prop2 { get; set; }
    }
    
    public class PhysicalAddress : SecondSubAddressBase
    {        
        public string Prop3 { get; set; }
    }
    
    public class MailingAddress : SecondSubAddressBase
    {        
        public string Prop4 { get; set; }
    }
