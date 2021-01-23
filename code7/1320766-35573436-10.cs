    class Client
    {
        public string id;
    
        public Client(string id)
        {
            this.id = id;
        }
    
        public void ClientRegister(Server server)
        {
            server.Register(PrintMessage);
        }
    
        public void ClientUnregister(Server server)
        {
            server.Unregister(PrintMessage); 
        }
    
        public void PrintMessage(string message)
        {
            Console.WriteLine("Client " + id + " recieved: " + message);
        }
    }
