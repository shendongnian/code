    public class User
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }    
    }
