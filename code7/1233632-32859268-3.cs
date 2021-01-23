        public Equipment
        {
             private IHolded holded;
             public Equipment(IHolded holded) { this.holded = holded; }
     
             public Bar Foo() { return holded.Foo() };
        }
