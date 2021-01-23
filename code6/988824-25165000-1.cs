    class Test
    {
        public delegate void TestEventHandler();
        private event TestEventHandler _testEvent;
    
        public event TestEventHandler TestEvent
        {
            add
            {
                _testEvent += value;
                _testEvent();
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
