    class tcp_connector
    {
        public event EnventHandler ServerOnlineChanged;
        protected virtual void OnServerOnlineChanged
        {
            EventHandler handler = ServerOnlineChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        private bool _serverOnline;
        public bool ServerOnline
        {
            get { return _serverOnline; }
            set {
                if (_serverOnline == value) return;
                _serverOnline = value;
                OnServerOnlineChanged();
                }
        }
    
        void thread_checkServer()
        {
            //do code
            ServerOnline = true;  // this will raise ServerOnlineChangedEvent
        }    
    }
