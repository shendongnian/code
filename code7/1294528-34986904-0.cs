    public class Sub1
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public int Value {get; set;}
    }
    
    public class Sub2
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public int Value {get; set;}
    }
    
    public class Sup
    {
        [Key]
        public int Id { get; set; }
        public int Sub1Id { get; set; }
        public int Sub2Id { get; set; }
        public virtual Sub1 Sub1 { get; set; }
        public virtual Sub2 Sub2 { get; set; }
    }
