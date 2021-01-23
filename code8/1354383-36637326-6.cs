    	static void Main(string[] args) {
    		//Similarly, start defining your client socket as soon as you start. 
    		clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    		loopConnect(3, 3); //for failure handling
    		string result = "";
    		do {
    			result = Console.ReadLine(); //you need to change this part
    			if (result.ToLower().Trim() != "exit") {
    				byte[] bytes = Encoding.ASCII.GetBytes(result); //Again, note that your data is actually of byte[], not string
    				//do something on bytes by using the reference such that you can type in HEX STRING but sending thing in bytes
    				clientSocket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, endSendCallback, clientSocket); //use async
    				//clientSocket.Send(bytes); use this for sync send
    			}
    		} while (result.ToLower().Trim() != "exit");
    	}
