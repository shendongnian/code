    class Test
    {
        public delegate void TestEventHandler();
        private TestEventHandler _testEvent;
    
        public event TestEventHandler TestEvent
        {
            add
            {
                _testEvent += value;
                value();
            }
            remove
            {
                _testEvent -= value;
            }
        }
    }
    var t = new Test();
    
    t.TestEvent += () =>
    {
        Console.WriteLine("Event fired");
    };
