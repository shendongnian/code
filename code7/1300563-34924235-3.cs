    class tcp_sender
    {
        private tcp_connector _connector;
        public tcp_sender()
        {
            _connector = new tcp_connector();
            // subscribe to event
            _connector.ServerOnlineChanged += tcp_connector_ServerOnlineChanged;
        }
        // the event handler for the ServerOnlineChanged event
        private void tcp_connector_ServerOnlineChanged(object sender, EventArgs e)
        {
            if (_connector.ServerOnline)
               button.color = color.green;
        }
    }
