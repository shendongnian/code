    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<B> { get; set; }
    }
    
    public class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("A")]
        public int AId { get; set; }    
        public virtual A A { get; set; }
    }
