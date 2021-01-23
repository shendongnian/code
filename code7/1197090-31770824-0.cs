            public class Customer
                {
                    [Key]
                    public int CustomerId { get; set; }
                    public string FirstName { get; set; }
                    public string MiddleName { get; set; }
                    public string LastName { get; set; }
                    public string Phone { get; set; }
                    public string Email { get; set; }
                    public string CustomerOtherDetails { get; set; }
                }
            
                public class CustomerAddress
                {
                    [ForeignKey("Customer")]
                    public int CustomerId { get; set; }
                    [ForeignKey("AddressType")]
                    public int AddressTypeId { get; set; }
                    [ForeignKey("Address")]
                    public int AddressId { get; set; }
                    [Key]
                    public DateTime DateFrom { get; set; }
                    public DateTime DateTo { get; set; }
                    public virtual Customer Customer { get; set; }
                    public virtual AddressType AddressType { get; set; }
                    public virtual Address Address { get; set; }
                }
            
                public class AddressType
                {
                    [Key]
                    public int AddressTypeId { get; set; }
                    public string AddressTypeDescriptiom { get; set; }
                }
            
                public class Address
                {
                    [Key]
                    public int AddressId { get; set; }
                    public string Line1 { get; set; }
                    public string Line2 { get; set; }
                    public string Line3 { get; set; }
                    public string City { get; set; }
            
                }
