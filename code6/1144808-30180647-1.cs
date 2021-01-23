    abstract class abstractClass
    {
        public int x;
    
        protected abstractClass(AbstractClassParameters p)
        {
            this.x = p.x;            
        }
    }
    
    class childClass : abstractClass
    {
        childClass(AbstractClassParameters p) : base(p) { }
    }
