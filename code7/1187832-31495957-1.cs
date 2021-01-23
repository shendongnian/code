    class ParentClass
    {
        public BaseClass( IEnumerable<int> ints )
        {  }
    }
    
    class ChildClass : BaseClass
    {
        public ChildClass( IEnumerable<int> ints ) : base( ints )
        {  }
    }
