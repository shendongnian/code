    class ParentClass
    {
        public BaseClass( params int[] ints )
        {  }
    }
    
    class ChildClass : BaseClass
    {
        public ChildClass( params int[] ints ) : base( ints )
        {  }
    }
