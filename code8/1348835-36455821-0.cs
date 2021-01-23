    public class User
    {
        public Guid Id { get; set; }
        [InverseProperty("User")]
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
    public class Address
    {
        public Guid AddressId { get; set; }
        [InverseProperty("Address")]
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
    public class UserAddress
    {
        [ForeignKey("UserId")]
        [InverseProperty("UserAddresses")]
        public User User { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("AddressId")]
        [InverseProperty("UserAddresses")]
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
