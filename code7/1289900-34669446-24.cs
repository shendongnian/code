		const int MAX_RECEIVE_ATTEMPT = 10;
		static int receiveAttempt = 0;
		private static void receiveCallback(IAsyncResult result) {
			System.Net.Sockets.Socket socket = null;
			try {
				socket = (System.Net.Sockets.Socket)result.AsyncState;
				if (socket.Connected) {
					int received = socket.EndReceive(result);
					if (received > 0) {
						receiveAttempt = 0;
						byte[] data = new byte[received];
						Buffer.BlockCopy(buffer, 0, data, 0, data.Length); //copy the data from your buffer
						//DO ANYTHING THAT YOU WANT WITH data, IT IS THE RECEIVED PACKET!
						//Notice that your data is not string! It is actually byte[]
						//For now I will just print it out
						Console.WriteLine("Server: " + Encoding.UTF8.GetString(data));
						socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket);
					} else if (receiveAttempt < MAX_RECEIVE_ATTEMPT) { //not exceeding the max attempt, try again
						++receiveAttempt;
						socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket);
					} else { //completely fails!
						Console.WriteLine("receiveCallback is failed!");
						receiveAttempt = 0;
						clientSocket.Close();
					}
				}
			} catch (Exception e) { // this exception will happen when "this" is be disposed...
				Console.WriteLine("receiveCallback is failed! " + e.ToString());
			}
		}
