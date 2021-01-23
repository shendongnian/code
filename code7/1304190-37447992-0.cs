    [Table("Products")]
    public class Product
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
