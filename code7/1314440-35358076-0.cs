    public class CustomerAddress {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id {get; set;}
       public int CustomerId {get; set;}
       
       [ForeignKey("CustomerId")]
       public Customer Customer
       public int AddressId {get; set;}
       [ForeignKey("AddressId")]
       public Address Address
       public int AddressType {get; set;}
    }
    public class Address {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id {get; set;}
       public string Street {get; set;}
       public string City{get; set;}
       public string State{get; set;}
       public string Country{get; set;}
       public string PostalCode{get; set;}
    }
