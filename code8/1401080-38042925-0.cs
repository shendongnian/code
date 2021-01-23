    public class User : Person
    {
        //[Required]
        //public Person Person { get; set; } Remove this line
        [Required]
        public string Username { get; set; }
    }
    [Table("Person")]
    public class Person : Entity
    {
        [Required]
        public List<User> Users { get; set; }
        public string Name { get; set; }
    }
