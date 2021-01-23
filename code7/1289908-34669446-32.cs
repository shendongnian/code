		const int MAX_RECEIVE_ATTEMPT = 10;
		static int receiveAttempt = 0; //this is not fool proof, obviously, since actually you must have multiple of this for multiple clients, but for the sake of simplicity I put this
		private static void receiveCallback(IAsyncResult result) {
			Socket socket = null;
			try {
				socket = (Socket)result.AsyncState; //this is to get the sender
				if (socket.Connected) { //simple checking
					int received = socket.EndReceive(result);
					if (received > 0) {
						byte[] data = new byte[received]; //the data is in the byte[] format, not string!
						Buffer.BlockCopy(buffer, 0, data, 0, data.Length); //There are several way to do this according to http://stackoverflow.com/questions/5099604/any-faster-way-of-copying-arrays-in-c in general, System.Buffer.memcpyimpl is the fastest
						//DO SOMETHING ON THE DATA IN byte[] data!! Yihaa!!
						Console.WriteLine(Encoding.UTF8.GetString(data)); //Here I just print it, but you need to do something else
						receiveAttempt = 0; //reset receive attempt
						socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket); //repeat beginReceive
					} else if (receiveAttempt < MAX_RECEIVE_ATTEMPT) { //fail but not exceeding max attempt, repeats
						++receiveAttempt; //increase receive attempt;
						socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket); //repeat beginReceive
					} else { //completely fails!
						Console.WriteLine("receiveCallback fails!"); //don't repeat beginReceive
						receiveAttempt = 0; //reset this for the next connection
					}
				}
			} catch (Exception e) { // this exception will happen when "this" is be disposed...
				Console.WriteLine("receiveCallback fails with exception! " + e.ToString());
			}
		}
