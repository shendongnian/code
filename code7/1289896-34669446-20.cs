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
					//you can use `result` to send something for your client if you want
					//this is the reason why you may want to list them
					//Do something with to convert result to bytes
					foreach(Socket socket in clientSockets)
						socket.Send(bytes); //send everything to all clients as bytes
				}
			} while (result.ToLower().Trim() != "exit");
		}
