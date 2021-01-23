    public class Person
    {
        public int ID { get; set; }
    
        [Required]
        [StringLength(40)]
        public string Email { get; set; }
    }
