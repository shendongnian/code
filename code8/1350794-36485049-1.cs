    public class A 
    {
        public virtual IList<B> Bs { get; set; }
    
        //if you need an IList<C>
        public IList<C> Cs
        {
            get { return Bs.SelectMany(b => b.Cs).ToList(); }
        }  
        //if you need an IEnumerable<C>
        public IEnumerable<C> Cs
        {
            get { return Bs.SelectMany(b => b.Cs); }
        }    
    }
