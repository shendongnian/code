    public class Contact
    {
        public PhysicalAddress PhysicalAddress { get; set; }
        public MailingAddress MailingAddress { get; set; }
    }
    
    public class AddressBase
    {
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public Country Country { get; set; }
        public PhoneNumber Landline { get; set; }
    }
    
    public class NationalAddress : AddressBase
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
    
    public class InternationalAddress : AddressBase
    {
        public string AdresRule1 { get; set; }
        public string AdresRule2 { get; set; }
        public string AdresRule3 { get; set; }
    }
    
    
    //I'm guessing Mailing and Physical is meant to know where to ship to, hence the "Transport" prefix.
    public class TransportAddressBase
    {
        **public AddressBase AddressBaseInformation{ get; set; }**
    
        public bool IsVerified { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
    
    
    
    public class PhysicalAddress : TransportAddressBase
    {       
        //Semi-detached/Terraced/Appartment/...
        public TypeOfBuilding Building { get; set; }
        public bool Occupied { get; set; }
    }
    
    public class MailingAddress : TransportAddressBase
    {       
        public bool AllowCommercialPress { get; set; }
        public bool AllowOfficialPress { get; set; }
    }
