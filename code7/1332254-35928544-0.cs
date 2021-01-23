    public class A
    {
        public int Id {get;set;}
        public ICollection<B> Bs {get;set;}
    }
    
    public class B
    {
        public bool IsEnabled {get;set;}
    }
