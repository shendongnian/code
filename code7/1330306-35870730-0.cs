    public class A
    {
        [Key]
        public int Id { get; set; }
        public int BId { get; set; }
        [ForeignKey("BId")]
        public B B { get; set; }
    }
    public class B
    {
        [Key]
        public int Id { get; set; }
    }
