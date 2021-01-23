    public class Contact
    {
        public PhysicalAddress PhysicalAddress { get; set; }
        public MailingAddress MailingAddress { get; set; }
    }
    
    public class AddressRule
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
    
    public class BaseAddress
    {
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
    
        public Country Country { get; set; }
        public PhoneNumber Landline { get; set; }
    
        public List<AddressRule> AdressRules { get; set; }
    
        public bool IsVerified { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
    
    public class PhysicalAddress : BaseAddress
    {        
        //Semi-detached/Terraced/Appartment/...
        public TypeOfBuilding Building { get; set; }
        public bool Occupied { get; set; }
    }
    
    public class MailingAddress : BaseAddress
    {       
        public bool AllowCommercialPress { get; set; }
        public bool AllowOfficialPress { get; set; }
    }
