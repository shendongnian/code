    public class A
    {
        [Key]
        public int Id { get; set; }
    
        public int? BId { get; set; }
        public B B { get; set; }
    }
    
    public class B
    {
        [Key]
        public int Id { get; set; }
    
        public int? AId { get; set; }
        public A A { get; set; }
    }
