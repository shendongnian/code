    class Server
    {
        public delegate void MsgSend(string message);
    
        private MsgSend msgSend;
    
        public void Register(MsgSend m)
        {
            msgSend += m;
            m("Registered");
        }
    
        public void Unregister(MsgSend m)
        {
            msgSend -= m; // <--- Change += to -=
            m("Unregistered");
        }
    
        public void SendMessage(string message)
        {
            //You have to check if msgSend is null:
            if (msgSend != null) this.msgSend(message);
            else Console.WriteLine("DONT HAVE ANY CLIENT!");
        }
    }
