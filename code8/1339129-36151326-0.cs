    class ABCommon
    {
        //common properties here
    }
    
    class B : ABCommon
    {
        public virtual A A { get; set; }
        //this property makes everything crazy if A inherits from B
    }
    
    public A : ABCommon
    {
        public virtual ICollection<B> Bs { get; set; }
    }
