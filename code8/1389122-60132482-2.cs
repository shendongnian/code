    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Timers;
    namespace SomeApp
    {
		public class UPnPDevDiscovery
		{
			/// <summary>
			/// Device search request
			/// </summary>
		private const string searchRequest = @"M-SEARCH * HTTP/1.1
	HOST: {0}:{1}
	MAN: ""ssdp:discover""
	MX: {2}
	ST: {3}
	";
			/// <summary>
			/// Advertisement multicast address
			/// </summary>
			private const string MulticastIP = "239.255.255.250";
			/// <summary>
			/// Advertisement multicast port
			/// </summary>
			private const int multicastPort = 1900;
			/// <summary>
			///  Time to Live (TTL) for multicast messages
			/// </summary>
			private const int multicastTTL = 4;
			private const int MaxResultSize = 8096;
			private const string DefaultDeviceType = "ssdp:all";
			private int searchTimeOut = 5; //Seconds
			private Socket socket;
			private SocketAsyncEventArgs sendEvent;
			
			public void FindDevices()
			{
				string request = string.Format(searchRequest, MulticastIP, multicastPort, this.searchTimeOut, DefaultDeviceType);
				Console.WriteLine("Sending: \n" + request);
				byte[] multiCastData = Encoding.UTF8.GetBytes(request);
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.SendBufferSize = multiCastData.Length;
				sendEvent = new SocketAsyncEventArgs();
				sendEvent.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(MulticastIP), multicastPort);
				sendEvent.SetBuffer(multiCastData, 0, multiCastData.Length);
				sendEvent.Completed += OnSocketSendEventCompleted;
				Timer t = new Timer(TimeSpan.FromSeconds(this.searchTimeOut + 1).TotalMilliseconds);
				t.Elapsed += (e, s) => {
					socket.Dispose();
					socket = null;
				};
				// Kick off the initial Send
				socket.SetSocketOption(SocketOptionLevel.IP,SocketOptionName.MulticastInterface, IPAddress.Parse(MulticastIP).GetAddressBytes());
				socket.SendToAsync(sendEvent);
				t.Start();
			}
			private void OnSocketSendEventCompleted(object sender, SocketAsyncEventArgs e)
			{
				if (e.SocketError != SocketError.Success)
				{
					Console.WriteLine("SocketError: " + e.SocketError);
					return;
				}
				switch (e.LastOperation)
				{
					case SocketAsyncOperation.SendTo:
						Console.WriteLine("Send complete");
						// When the initial multicast is done, get ready to receive responses
						e.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
						byte[] receiveBuffer = new byte[MaxResultSize];
						socket.ReceiveBufferSize = receiveBuffer.Length;
						e.SetBuffer(receiveBuffer, 0, MaxResultSize);
						Console.WriteLine("Waiting for response");
						socket.ReceiveFromAsync(e);
						break;
					case SocketAsyncOperation.ReceiveFrom:
						Console.WriteLine("Received:");
						// Got a response, so decode it
						string result = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);
						if (result.StartsWith("HTTP/1.1 200 OK", StringComparison.InvariantCultureIgnoreCase))
							Console.WriteLine(result);
						else
							Console.WriteLine("INVALID SEARCH RESPONSE\n" + result);
						if (socket != null)// and kick off another read
							socket.ReceiveFromAsync(e);                    
						break;
					default:
						Console.WriteLine("***"+e.LastOperation);
						break;
				}
			}
		}
    }
