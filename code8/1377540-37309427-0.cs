        class Container<T>
        {
            public T Value { get; set; }
        }
        static AsyncLocal<Container<bool>> _value = new AsyncLocal<Container<bool>>();
        static void Main(string[] args)
        {
            A().Wait();
        }
        static async Task A()
        {
            await B_Start();
            await C();
        }
        static Task B_Start()
        {
            _value.Value = new Container<bool>();
            return B();
        }
        static async Task B()
        {
            _value.Value.Value = true;
        }
        static async Task C()
        {
            if (!_value.Value.Value) throw new Exception();
        }
