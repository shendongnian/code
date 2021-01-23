        if (received > 0) {
			byte[] data = new byte[received]; //the data is in the byte[] format, not string!
			//DO SOMETHING ON THE DATA int byte[]!! Yihaa!!
			Console.WriteLine(Encoding.UTF8.GetString(data)); //Here I just print it, but you need to do something else						
			//Message retrieval part
			//Suppose you only want to declare that you receive data from a client to that client
			string msg = "I receive your message on: " + DateTime.Now;
			socket.Send(Encoding.ASCII.GetBytes(msg)); //Note that you actually send data in byte[]
			Console.WriteLine("I sent this message to the client: " + msg);
			receiveAttempt = 0; //reset receive attempt
			socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket); //repeat beginReceive
		}
