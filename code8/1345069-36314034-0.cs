    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }        
        [Column("Address_Id")]
        public int AddressId { get; set; }
    }
