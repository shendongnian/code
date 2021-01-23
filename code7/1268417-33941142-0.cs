    public sealed class B : O
    {
        public B(string val, O instance)
            : base(val)
        {
            instanceO = instance;
            instanceO.ValueChanged += MyMethod;
        }
        private O instanceO;
    }
