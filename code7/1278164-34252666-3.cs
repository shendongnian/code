    public class SenderClass : ISenderClass
        {
            private Queue<int> _myQueue = new Queue<int>();
            private Thread _worker;
            private readonly Action<int> _senderAction;
            public SenderClass()
            {
                _worker = new Thread(RunWorker) { IsBackground = true };
                _worker.Start();
                _senderAction = DefaultMessageSendingAction;
            }
            public SenderClass(Action<int> senderAction)
            {
                //Create a background worker
                _worker = new Thread(RunWorker) { IsBackground = true };
                _worker.Start();
                _senderAction = senderAction;
            }
            private void RunWorker() //This is the background worker's method
            {
                while (true) //Keep it running
                {
                    lock (_myQueue) //No fiddling from other threads
                    {
                        while (_myQueue.Count != 0) //Pop elements if found
                            SendMessage(_myQueue.Dequeue()); //Send the element
                    }
                    Thread.Sleep(50); //Allow new elements to be inserted
                }
            }
            private void SendMessage(int element)
            {
                _senderAction(element);
            }
            private void DefaultMessageSendingAction(int item)
            {
                /* whatever happens during sending */
            }
            public void AddToQueue(int element)
            {
                Task.Run(() => //Async method will return at ones, not slowing the caller
                {
                    lock (_myQueue) //Lock queue to insert into it
                    {
                        _myQueue.Enqueue(element);
                    }
                });
            }
        }
        public class TestClass
    {
        private SenderClass _sender;
        private Queue<int> _messages;
        [TestInitialize]
        public void SetUp()
        {
            _messages = new Queue<int>();
            _sender = new SenderClass(DummyMessageSendingAction);
        }
        private void DummyMessageSendingAction(int item)
        {
            _messages.Enqueue(item);
        }
        [TestMethod]
        public void TestMethod1()
        {
            //This isn't a great test, but I think you get the idea
            int message = 42;
            _sender.AddToQueue(message);
            Thread.Sleep(100);
            CollectionAssert.Contains(_messages, 42);            
        }
    }
