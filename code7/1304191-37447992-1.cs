    [Table("Categories")]
    public class Category
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
