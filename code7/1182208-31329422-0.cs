    public inteface IFoo
    {
        void DoSomething();
    }
    public IntFoo : IFoo
    {
        private int _value;
        public IntFoo(int value)
        {
            _value = value;
        }
        void DoSomething()
        {
            IntDoSomething(_value);
        }
    }
