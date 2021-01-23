    public class B
    {
        public int BId { get; set; }
    }
    public class C : B
    {
        //FK that links C to A
        public int FK_C_AId { get; set; }
    }
    
    public class D : B
    {
        //FK that links D to A
        public int FK_D_AId { get; set; }
    
        public ICollection<E> Es { get; set; }
    
        public D()
        {
            Es = new List<E>();
        }
    }
