    public class Foo
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    
        [OneToMany(ReadOnly = true)]
        public List<Bar> Bars { get; set; }
    }
    
    public class Bar
    {
        [PrimaryKey]
        public Guid Id { get; set; }
    
        [ForeignKey(typeof(Foo))]
        public Guid ParentId { get; set; }
    
        [ManyToOne]
        public Foo ParentFoo { get; set; }
    }
