		private const int BUFFER_SIZE = 4096;
		private static byte[] buffer = new byte[BUFFER_SIZE]; //buffer size is limited to BUFFER_SIZE per message
        private static List<Socket> clientSockets = new List<Socket>(); //may be needed by you
		private static void acceptCallback(IAsyncResult result) { //if the buffer is old, then there might already be something there...
			Socket socket = null;
			try {
				socket = serverSocket.EndAccept(result); // The objectDisposedException will come here... thus, it is to be expected!
				//Do something as you see it needs on client acceptance such as listing
                clientSockets.Add(socket); //may be needed later
				socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket);
				serverSocket.BeginAccept(new AsyncCallback(acceptCallback), null); //to receive another client
			} catch (Exception e) { // this exception will happen when "this" is be disposed...        
				//Do something here
				Console.WriteLine(e.ToString());
			}
		}
