    class A
    {
        public virtual bool Value { get; set; }
    }
    class B : A
    {
        public override bool Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                if (base.Value != value)
                {
                    base.Value = value;
                    Foo();
                }
            }
        }
        private void Foo()
        {
            // code I want to run when base class property changes
        }
    }
