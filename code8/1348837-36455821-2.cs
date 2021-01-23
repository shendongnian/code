    public class User
    {
        public Guid Id { get; set; }
        [InverseProperty("User")]
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
    public class Address
    {
        public Guid AddressId { get; set; }
        public UserAddress UserAddresses { get; set; }
    }
    public class UserAddress
    {
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserAddresses")]
        public User User { get; set; }
        public Guid UserId { get; set; }        
        
    }
