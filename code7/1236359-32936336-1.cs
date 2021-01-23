    public class Color
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
