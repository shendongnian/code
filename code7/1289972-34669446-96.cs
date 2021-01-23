    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TcpListenerConsoleApplication {
    	class Program {
    		const int PORT_NO = 2201;
    		const string SERVER_IP = "127.0.0.1";
    		static Socket serverSocket;
    		static void Main(string[] args) {
    			//---listen at the specified IP and port no.---
    			Console.WriteLine("Listening...");
    			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    			serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT_NO));
    			serverSocket.Listen(4); //the maximum pending client, define as you wish
    			serverSocket.BeginAccept(new AsyncCallback(acceptCallback), null);      
    			string result = "";
    			do {
    				result = Console.ReadLine();
    			} while (result.ToLower().Trim() != "exit");
    		}
    		
    		private const int BUFFER_SIZE = 4096;
    		private static byte[] buffer = new byte[BUFFER_SIZE]; //buffer size is limited to BUFFER_SIZE per message
    		private static void acceptCallback(IAsyncResult result) { //if the buffer is old, then there might already be something there...
    			Socket socket = null;
    			try {
    				socket = serverSocket.EndAccept(result); // The objectDisposedException will come here... thus, it is to be expected!
    				//Do something as you see it needs on client acceptance
    				socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), socket);
    				serverSocket.BeginAccept(new AsyncCallback(acceptCallback), null); //to receive another client
    			} catch (Exception e) { // this exception will happen when "this" is be disposed...        
    				//Do something here				
    				Console.WriteLine(e.ToString());
    			}
    		}
    
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
    						Buffer.BlockCopy(buffer, 0, data, 0, data.Length); //There are several way to do this according to https://stackoverflow.com/questions/5099604/any-faster-way-of-copying-arrays-in-c in general, System.Buffer.memcpyimpl is the fastest
    						//DO SOMETHING ON THE DATA int byte[]!! Yihaa!!
    						Console.WriteLine(Encoding.UTF8.GetString(data)); //Here I just print it, but you need to do something else						
    
    						//Message retrieval part
    						//Suppose you only want to declare that you receive data from a client to that client
    						string msg = "I receive your message on: " + DateTime.Now;						
    						socket.Send(Encoding.ASCII.GetBytes(msg)); //Note that you actually send data in byte[]
    						Console.WriteLine("I sent this message to the client: " + msg);
    
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
    
    	}
    }
