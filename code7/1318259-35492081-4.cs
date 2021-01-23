    public class Foo
    {
        [Key]
        public int Id {get;set;}
        [ForeignKey("BigFoo")]
        public int? BigFooId {get;set;}
        public virtual BigFoo BigFoo {get;set;}
        public virtual ICollection<BigFoo> BigFoo{get;set;}// Add this property
    }
    
    public class BigFoo
    {
        [Key]
        public int Id {get;set;}
        [ForeignKey("Foo")]
        public int? FooId { get; set; }
        public virtual Foo Foo {get;set;}
        public virtual ICollection<Foo> Foos{get;set;}// Add this property
    }
