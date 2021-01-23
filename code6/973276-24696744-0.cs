    public class Person
    {
        [Key] // <--- this needs to be identified here or in the DbContext you setup
        public Guid ID { get; set; }
    }
