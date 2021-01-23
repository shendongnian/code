    public class IntegerProperty : ProductProperty
    {
        [Required]
        [Column("Value1")]
        public int Value { get; set; }
    }
    public class StringProperty : ProductProperty
    {
        [Required]
        [Column("Value2")]
        public string Value { get; set; }
    }
