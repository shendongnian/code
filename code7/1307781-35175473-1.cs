    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        [ForeignKey(typeof(Address))]
        public int AddressId { get; set; }
    
        public string Name { get; set; }
        public string Surname { get; set; }
    
        [ManyToOne]
        public Address mAddress { get; set; }
    }
    
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public string Street { get; set; }
    
        public string City { get; set; }
        public string Country { get; set; }
    
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Person> Persons { get; set; }
    }
