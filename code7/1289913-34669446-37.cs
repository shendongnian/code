		private const int BUFFER_SIZE = 4096;
		private static byte[] buffer = new byte[BUFFER_SIZE]; //buffer size is limited to BUFFER_SIZE per message
		private static void endConnectCallback(IAsyncResult ar) {
			try {
				clientSocket.EndConnect(ar);
				if (clientSocket.Connected) {
					clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), clientSocket);
				} else {
					Console.WriteLine("End of connection attempt, fail to connect...");
				}
			} catch (Exception e) {
				Console.WriteLine("End-connection attempt is unsuccessful! " + e.ToString());
			}
		}
