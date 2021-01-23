    class Test
    {
        public delegate void TestEventHandler();
        private event TestEventHandler TestEvent;
    
        public event TestEventHandler TestEventProp
        {
            add
            {
                TestEvent += value;
                TestEvent();
            }
            remove
            {
                TestEvent -= value;
            }
        }
    }
    var t = new Test();
    
    t.TestEventProp += () =>
    {
        Console.WriteLine("Event fired");
    };
