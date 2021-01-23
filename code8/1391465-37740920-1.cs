    [Table("Items")]
    public class Item
    {
        public Item(){
          Id=Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
