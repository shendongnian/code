    [Table("Client")]
    public class Client {
        
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public Address Address { get; set; }
        // This relationship is in fact a ManyToOne relationship,
        // but we model it as a ManyToMany to avoid adding foreign key to this entity
        [ManyToMany(typeof(AddressesClients))]
        public Address[] Addresses { 
            get { return Address != null ? new []{ Address } : Address; } 
            set { Address = value.FirstOrDefault(); }
        }
    }
    [Table("Address")]
    public class Address
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string SomeFields { get; set; }
        [ManyToMany(typeof(AddressesClients), ReadOnly = true)]
        public List<Client> Clients { get; set; }
    }
    // Intermediate table that defines the relationship between Address and Client
    class AddressesClients {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }
        [ForeignKey(typeof(Address))]
        public int AddressId { get; set; }
    }
