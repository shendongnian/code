    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        public int? AddressID { get; set; }
        [ForeignKey("Address")]
        public virtual Address Address { get; set; }
    }
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        public int PersonID { get; set; }
        [ForeignKey("Person")]
        public virtual Person Person { get; set; }
    }
