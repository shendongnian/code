    public class Contract
    {
        public int ContractId { get; set; }
        public int PersonId { get; set; }
        public Person Customer { get; set; }  // Use a navigation property to relate
    }
    
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public ICollection<Contract> Contracts { get; set; }  // A person can have many contracts, no?
    }
