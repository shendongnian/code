    public class PersonEntity
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<AddressEntity> Addresses { get; set; }
    }
    public class AddressEntity
    {
        public int AddressId  { get; set; }  
        public int PersonId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressPostCode { get; set; }
        public bool   IsPrimary{ get; set; }
    }
