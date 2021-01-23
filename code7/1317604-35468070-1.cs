    class EmpoweredSubscriber : ISubscriber
    {
        private readonly DisconnectWorker _worker;
        private readonly DisconnectHelper _helper;
        public EmpoweredSubscriber(DisconnectWorker worker, DisconnectHelper helper)
        {
            _worker = worker;
            _helper = helper;
        }
        public void OnConnected()
        {
        }
        public void OnDisconnected()
        {
            _worker.DoWork();
            _helper.DoHelp();
            // more...
        }
    }
