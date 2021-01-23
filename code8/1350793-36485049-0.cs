    public class A 
    {
        public virtual IList<B> Bs { get; set; }
    
        public IList<C> Cs
        {
            get { return Bs.SelectMany(b => b.Cs); }
        }    
    }
