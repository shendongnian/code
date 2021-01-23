    [Table("Brands")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
