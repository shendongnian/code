    public class Foo 
    {
        public ICollection<Bar> Bars { get; set; }
    } 
    
    public class Bar
    {
        public ICollection<Foo> Foos { get; set; }
    }
