    class A
    {
        private readonly int _value;
        private readonly Action<int> _action;
        public A(int value, Action<int> action)
        {
            _value = value;
            _action = action;
        }
        public void M() { _action(_value); }
    }
    public void Run()
    {
        int someValue = 17;
        Task q = Task.Run((Action)(new A(someValue, LongTask).M));
    }
