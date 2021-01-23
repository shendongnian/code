    public class Boo
    {
        [Key, ForeignKey("Foo")]
        public string BooId{get;set;}
        public Foo Foo{get;set;}
    }
