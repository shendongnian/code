    class MyClass 
    {
        private PushSocket _pushSocket;
        private BlockingCollection<NetMQMessage> _toSend = new BlockingCollection<NetMQMessage>();
        MyClass() 
        {
            _pushSocket = new PushSocket();
            _pushSocket.Bind("someaddress");
            Task.Factory.StartNew(WorkerThread, TaskCreationOptions.LongRunning);
        }
        private void WorkerThread() 
        {
            while (true) 
            {
                NetMQMessage message = _toSend.Take();
                _pushSocket.SendMultipartMessage(message);
            }
        }
        public void Method1(NetMQMessage message) 
        {
            _toSend.Add(message);
        }
        public void Method2(NetMQMessage message) 
        {
            _toSend.Add(message);
        }
    }
