    public class MyClass
    {
        private SomeObject object1;
        private AnotherObject object2;
    
        public MyClass()
        {
            object1 = new SomeObject();
            object2 = new AnotherObject();
    
            object1.AThreadedEvent += ThreadedEventHandler1;
            object2.AnotherThreadedEvent += ThreadedEventHandler2;
        }
    
        // This runs in its own thread!
        // Only add the real function call to the queue
        public void ThreadedEventHandler1()
        {
            tasks.Add(ThreadedEventHandler1_really);
        }
    
        private void ThreadedEventHandler1_really()
        {
            // DO STUFF HERE
        }
    
        // This runs in its own thread!
        // Only add the real function call to the queue
        public void ThreadedEventHandler2()
        {
            tasks.Add(ThreadedEventHandler2_really);
        }
    
        // here is the actual logic of your function
        private void ThreadedEventHandler2_really()
        {
            // DO STUFF HERE
        }
    
        // the queue of the tasks
        BlockingCollection<Action> tasks = new BlockingCollection<Action>();
    
        // this method never returns, it is blocked forever 
        // and the only purpose of i is to do the functions calls when they added to the queue
        // it is done in the thread of this instance
        public void StartConsume()
        {
            foreach (Action action in tasks.GetConsumingEnumerable())
            {
                // add logic before call
                action();
                // add logic after call
            }
        }
    }
