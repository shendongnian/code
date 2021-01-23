    	private static void endSendCallback(IAsyncResult ar) {
    		try {
    			SocketError errorCode;
    			int result = clientSocket.EndSend(ar, out errorCode);
    			Console.WriteLine(errorCode == SocketError.Success ?
    				"Successful! The size of the message sent was :" + result.ToString() :
    				"Error with error code: " + errorCode.ToString() //you probably want to consider to resend if there is error code, but best practice is to handle the error one by one
    			);
    		} catch (Exception e) { //exception
    			Console.WriteLine("Unhandled EndSend Exception! " + e.ToString());
    			//do something like retry or just report that the sending fails
    			//But since this is an exception, it probably best NOT to retry
    		}
    	}
