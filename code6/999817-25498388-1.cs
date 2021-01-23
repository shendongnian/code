    class Parent
    {
        //public Guid id { get; set; }
        //public List<Child> children = new List<Child>();
    
        public virtual Guid Id { get; set; }
    
        // property instead of a field mapping
        public virtual IList<Child> Children {get; set;} 
    }
    
    class Child
    {
        public virtual int Index{ get; set; }
    
        // new property 
        public virtual Parent Parent { get; set; }
        public virtual IList<GrandChild> Grandchildren { get; set; }
    }
