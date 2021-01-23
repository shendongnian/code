    class tcp_connector
    {
        // standard event pattern
        public event EnventHandler ServerOnlineChanged;
        protected virtual void OnServerOnlineChanged
        {
            EventHandler handler = ServerOnlineChanged; // for thread safety
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        private bool _serverOnline;
        public bool ServerOnline // implement as property
        {
            get { return _serverOnline; }
            set {
                if (_serverOnline == value) return;
                _serverOnline = value;
                OnServerOnlineChanged(); // raise event
                }
        }
    
        void thread_checkServer()
        {
            //do code
            // be sure to use the property ServerOnline, not the
            // field _serverOnline! 
            // the property setter will raise ServerOnlineChangedEvent
            ServerOnline = true;
        }    
    }
