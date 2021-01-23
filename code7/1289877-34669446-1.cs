		static void Main(string[] args) {
			//---listen at the specified IP and port no.---
			Console.WriteLine("Listening...");
			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT_NO));
			serverSocket.Listen(4); //the maximum pending client, define as you wish
			serverSocket.BeginAccept(new AsyncCallback(acceptCallback), null);      
            //other stuffs
        }
