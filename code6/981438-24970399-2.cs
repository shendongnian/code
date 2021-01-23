    using System;
    using System.Net;
    using System.Linq;
    using System.Net.Sockets;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    
    namespace LocalHostName
    {
    	class Program
    	{
    		static void Main (string[] args)
    		{
    			var ipAddresses = Dns.GetHostAddresses ("www.google.com");
    			Socket socket;
                
    			for (int i = 0; i < ipAddresses.Length; i++) {
    				socket = new Socket (ipAddresses[i].AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    
    				try {
    					socket.Connect (ipAddresses[i], 80);
    					Console.WriteLine ("LocalEndPoint: {0}", socket.LocalEndPoint);
    					break;
    				} catch {
    					socket.Dispose ();
    					socket = null;
                        
    					if (i + 1 == ipAddresses.Length)
    						throw;
    				}
    			}
                
    			Console.ReadLine ();
    		}
    	}
    }
