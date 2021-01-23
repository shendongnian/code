    public partial class Person
    { 
        public int Id { get; set; }
        public string Nome { get;set;}
        public DateTime? DateTime { get; set; }
    }
    public partial class Person
    {
        [NotMapped]
        public string ExtendProperties { get;set;}
    }
