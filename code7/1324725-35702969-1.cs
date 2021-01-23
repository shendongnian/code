    class Connector
    {
        public string msg { get; set; }
        public event EventHandler MessageReceived;
        WebSocket websocket = new WebSocket("ws://192.168.1.103:2012/");
        public void Connect()
        {
            websocket.Opened += new EventHandler(websocket_Opened);
            websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            websocket.Open();
        }
        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            msg = e.Message;
            if(MessageReceived != null)
                MessageReceived(this, EventArgs.Empty);
        }
        private void websocket_Opened(object sender, EventArgs e)
        {
            websocket.Send("Status");
        }   
    }
