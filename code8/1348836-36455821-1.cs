    public class User
    {
        public Guid Id { get; set; }
        [InverseProperty("User")]
        public ICollection<Address> Addresses { get; set; }
    }
    public class Address
    {
        public Guid AddressId { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Addresses")]
        public User User { get; set; }
        public Guid UserId { get; set; }
    } 
