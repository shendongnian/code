    public class A
    {
        public int Id { get; set; }
        public List<B> bs = new List<B>();
        public List<C> cs = new List<C>();
    }
    
    public class B
    {
        public int CPMCId { get; set; }
    }
    
    public class C
    {
        public int CPMCId { get; set; }
    }
