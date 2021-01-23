    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TcpClientConsoleApplication {
    	class Program {
    		const int PORT_NO = 2201;
    		const string SERVER_IP = "127.0.0.1";
    		static Socket clientSocket; //put here
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
    
    		static void loopConnect(int noOfRetry, int attemptPeriodInSeconds) {
    			int attempts = 0;
    			while (!clientSocket.Connected && attempts < noOfRetry) {
    				try {
    					++attempts;
    					IAsyncResult result = clientSocket.BeginConnect(IPAddress.Parse(SERVER_IP), PORT_NO, endConnectCallback, null);
    					result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(attemptPeriodInSeconds));
    					System.Threading.Thread.Sleep(attemptPeriodInSeconds * 1000);
    				} catch (Exception e) {
    					Console.WriteLine("Error: " + e.ToString());
    				}
    			}
    			if (!clientSocket.Connected) {
    				Console.WriteLine("Connection attempt is unsuccessful!");
    				return;
    			}
    		}
    
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
    						Buffer.BlockCopy(buffer, 0, data, 0, data.Length); //There are several way to do this according to https://stackoverflow.com/questions/5099604/any-faster-way-of-copying-arrays-in-c in general, System.Buffer.memcpyimpl is the fastest
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
    	}
    }
