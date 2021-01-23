    public abstract class Bar : IChild<Foo>, IBar
    {
        private Foo parent;
        public Foo Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public abstract void DoSomething();
    }
