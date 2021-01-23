        const int PORT_NO = 2201;
        const string SERVER_IP = "127.0.0.1";
        static Socket serverSocket; //put here as static
        static void Main(string[] args) {
			//---listen at the specified IP and port no.---
			Console.WriteLine("Listening...");
			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT_NO));
			serverSocket.Listen(4); //the maximum pending client, define as you wish
            //your next main routine
        }
            
