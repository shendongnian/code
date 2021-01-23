    class Baseclass
    {
        private Parameters parameters;
        public BaseClass(Parameters parameters)
        {
            this.parameters = parameters;
        }
    }
    class Derived : Baseclass
    {
        public Derived(Parameters parameters) : base(parameters) { }
    }
    class Parameters
    {
        int a, b, c, d, e, etc.
    }
