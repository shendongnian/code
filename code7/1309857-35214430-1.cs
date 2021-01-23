    public class PostalContact
    {
        public string PartyId { get; set; }
        public string TypeName { get; set; }
        public string Address1 { get; set; }
        public object Address2 { get; set; }
        public object Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
    
    public class PhoneContact
    {
        public string PartyId { get; set; }
        public string TypeName { get; set; }
        public string CountryCode { get; set; }
        public string Telephone { get; set; }
        public object AdditionalData { get; set; }
        public string TextMessageOK { get; set; }
    }
    
    public class Property
    {
        public string PartyId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class Member
    {
        public string xmlns { get; set; }
        public string PartyId { get; set; }
        public string PartyTypeName { get; set; }
        public string RoleId { get; set; }
        public string BusinessUnitCode { get; set; }
        public object CardId { get; set; }
        public PostalContact PostalContact { get; set; }
        public List<PhoneContact> PhoneContact { get; set; }
        public List<Property> Property { get; set; }
    }
    
    public class SoMemberProfileDataSet
    {
        public string xmlnsmoso { get; set; }
        public Member Member { get; set; }
    }
    
    public class RootObject
    {
        public SoMemberProfileDataSet soMemberProfileDataSet { get; set; }
    }
