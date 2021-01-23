    public class Item
    {
        [Key]
        public Guid Id { get; set; };
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
