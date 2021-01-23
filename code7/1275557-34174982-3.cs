    class A
    {
        public int value;
        private readonly Action<int> _action;
        public A(int value, Action<int> action)
        {
            this.value = value;
            _action = action;
        }
        public void M() { _action(value); }
    }
    public void Run()
    {
        A a = new A(17, LongTask);
        Task q = Task.Run((Action)a.M);
        a.value = 19;
    }
