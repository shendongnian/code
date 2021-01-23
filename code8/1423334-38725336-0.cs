    class Logic : WebSocketBase, WebSocketService
    {
        public void onReceive(string msg)
        {
             Console.WriteLine("Received message")
             // Call method defined in base
             sendData(msg);
        }
    }
