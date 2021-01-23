	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Text;
	public class TcpConnection
	{
		private const int BUF_SIZE = 1024;
		private readonly byte[] buffer = new byte[BUF_SIZE];
		private readonly TcpClient client = new TcpClient();
		public void Start(IPAddress ip, int port)
		{
			client.BeginConnect(ip, port, ConnectCallback, null);
		}
		private void ConnectCallback(IAsyncResult result)
		{
			client.EndConnect(result);
			Console.WriteLine("Connected!");
		}
		private void StartRead()
		{
			if(!client.Connected)
			{
				Console.WriteLine("Disconnected, can't read.");
				return;
			}
			NetworkStream stream = client.GetStream();
			stream.BeginRead(buffer, 0, BUF_SIZE, ReadCallback, stream);		
		}
		private void ReadCallback(IAsyncResult result)
		{
			NetworkStream stream = (NetworkStream)result.AsyncState;
			int bytesRead = stream.EndRead(result);
			Console.WriteLine("Read Callback!");
			if (bytesRead > 0)
			{
				string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
				Console.WriteLine("Stream got \n{0}", response);
			}
			StartRead();
		}
	}
