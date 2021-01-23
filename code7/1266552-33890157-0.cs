    public class ManualResetEventPlayground
    {
        public ManualResetEventPlayground()
        {
            SomeEvent += (sender, e) =>
            {
                // Opens the door, blocked code will resume
                Console.WriteLine("Opening the door to let the method return...");
                _resetEvent.Set();
            };
            Task.Run(() => MethodThatMustWaitUntilSomeEventIsFired());
            Task.Run(() => MethodThatFiresTheEvent());
        }
        private event EventHandler SomeEvent;
        private static readonly ManualResetEventSlim _resetEvent = new ManualResetEventSlim(false);
        public string MethodThatMustWaitUntilSomeEventIsFired()
        {
            // Some stuff to do before blocking
            try
            {
                // This will block this thread until
                // the event is fired and opens the door
                Console.WriteLine("Blocking the thread calling the method");
                _resetEvent.Wait();
            }
            finally
            {
                _resetEvent.Reset();
            }
            Console.WriteLine("Now this method can be returned!");
            return "finished";
        }
        public void MethodThatFiresTheEvent()
        {
            Console.WriteLine("Firing the event...");
            if (SomeEvent != null) SomeEvent(this, new EventArgs());
        }
    }
