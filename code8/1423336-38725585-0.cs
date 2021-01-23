    interface WebSocketService
    {
        void onReceive(WebSocketBase sender, String msg);
    }
    class Logic : WebSocketService
    {
        public void onReceive(WebSocketBase sender, string msg)
        {
             sender.send("blah");
        }
    }
    class WebSocketBase
    {  
        ...
    
        private void webSocketClient_MessageReceived(object sender, MessageEventArgs e)
        {
            webService.onReceive(this, e.Data);
        }
    
        public void send(string channel)
        {
            webSocketClient.Send(channel);
        }
    
        ...    
    }
