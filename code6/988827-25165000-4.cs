    class Test
    {
        public delegate void TestEventHandler(int arg);
        private TestEventHandler _testEvent;
        private readonly _defaultEventArg = 42;
    
        public event TestEventHandler TestEvent
        {
            add
            {
                _testEvent += value;
                value(_defaultEventArg);
            }
            remove
            {
                _testEvent -= value;
            }
        }
    }
    var t = new Test();
    
    t.TestEvent += (val) =>
    {
        Console.WriteLine("Event fired: " + val);
    };
