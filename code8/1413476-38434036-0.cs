    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Bar{ get; set; }
        public string Foo { get; set; }
    }
     string p1 = "x";
     var query1 = new Context().Tests.Where(F => p1.Equals(F.Bar));
    
     var query2 = new Context().Tests.Where(F => p1.Equals(F.Foo));
