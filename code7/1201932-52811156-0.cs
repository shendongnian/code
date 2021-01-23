    static void Main(string[] args) {
        //---listen at the specified IP and port no.---
        Console.WriteLine("Listening...");
        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT_NO));
        serverSocket.Listen(4); //the maximum pending client, define as you wish
        serverSocket.BeginAccept(new AsyncCallback(acceptCallback), null);      
    
        //normally, there isn't anything else needed here
        string result = "";
        do {
            result = Console.ReadLine();
            if (result.ToLower().Trim() != "exit") {
                byte[] bytes = null;
                //you can use `result` and change it to `bytes` by any mechanism which you want
                //the mechanism which suits you is probably the hex string to byte[]
                //this is the reason why you may want to list the client sockets
                foreach(Socket socket in clientSockets)
                    socket.Send(bytes); //send everything to all clients as bytes
            }
        } while (result.ToLower().Trim() != "exit");
    }
