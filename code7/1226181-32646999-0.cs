    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace server
    {
    	internal class Server
    	{
    		private static readonly IPAddress sr_ipAddress = IPAddress.Parse("127.0.0.1");
    		public static void Main(string[] args)
    		{
    			Server server = new Server();
    			server.Start();
    			Console.ReadKey();
    		}
    		TcpListener Listener = new TcpListener(sr_ipAddress, 8888);
    		HashSet<Client> Clients = new HashSet<Client>();
    		object syncGate = new object();
    		public void Start()
    		{
    			Listener.Start();
    			Console.WriteLine("Server started");
    			StartAccept();
    		}
    		private void StartAccept()
    		{
    			Listener.BeginAcceptTcpClient(HandleAsyncConnection, Listener);
    		}
    		private void HandleAsyncConnection(IAsyncResult res)
    		{
    			StartAccept(); //listen for new connections again
    			var clientSocket = Listener.EndAcceptTcpClient(res);
    			var client = new Client(this, clientSocket);
    			client.StartClient();
    			lock (syncGate)
    			{
    				Clients.Add(client);
    				Console.WriteLine("New Client connected {0} => {1}", client.ClientSocket.GetHashCode(), client.ClientName);
    			}
    		}
    		internal void OnDisconnected(Client client)
    		{
    			lock (syncGate)
    			{
    				Clients.Remove(client);
    				Console.WriteLine("Client disconnected {0} => {1}", client.ClientSocket.GetHashCode(), client.ClientName);
    			}
    		}
    		internal void OnMessageReceived(Client sender, string message)
    		{
    			lock (syncGate)
    			{
    				Console.WriteLine("{0}: {1}", sender.ClientName, message);
    				foreach (var client in Clients)
    					client.OnMessageReceived(sender, message);
    			}
    		}
    	}
    
    	internal class Client
    	{
    		public readonly Server Server;
    		public TcpClient ClientSocket;
    		public string ClientName { get; set; }
    		public Client(Server server, TcpClient clientSocket)
    		{
    			Server = server;
    			ClientSocket = clientSocket;
    			var netStream = ClientSocket.GetStream();
    			var listen = new BinaryReader(netStream);
    			ClientName = listen.ReadString();
    		}
    		public void StartClient()
    		{
    			var clientThread = new Thread(Chat);
    			clientThread.Start();
    		}
    		private void Chat()
    		{
    			try
    			{
    				var netStream = ClientSocket.GetStream();
    				var listen = new BinaryReader(netStream);
    				while (true)
    				{
    					try
    					{
    						var message = listen.ReadString();
    						Server.OnMessageReceived(this, message);
    					}
    					catch (Exception ex)
    					{
    						listen.Close();
    						netStream.Close();
    						Console.WriteLine(ex.Message);
    						return;
    					}
    				}
    			}
    			finally
    			{
    				Server.OnDisconnected(this);
    			}
    		}
    		internal void OnMessageReceived(Client sender, string message)
    		{
    			var netStream = ClientSocket.GetStream();
    			var send = new BinaryWriter(netStream);
    			send.Write(sender.ClientName + ": " + message);
    		}
    	}
    }
