    abstract class abstractClass
    {
        public int x { get; private set; }
        public int y { get; private set; }
    
        protected abstractClass(int x) : this(x, defaultY) {}
        protected abstractClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    class childClass : abstractClass
    {
        childClass(int x)
            : base(x)
        {
        }
    }
    class childClass2 : abstractClass
    {
        childClass(int x, int y)
            : base(x,y)
        {
        }
    }
