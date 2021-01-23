    public class ServerEngine
	{
		private List<NetworkStream> connectedUsers = new List<NetworkStream>();
		private int processedRequestsAmount = 0;
		private Stopwatch sw = new Stopwatch();
		public ServerEngine()
		{
		}
		public void Start(IPAddress ipAddress, int port)
		{
			TcpListener listener = new TcpListener(ipAddress, port);
			try
			{
				listener.Start();
				AcceptClientsAsync(listener);
				while (true)
				{
					Console.ReadKey(true);
					Console.WriteLine("Processed requests: " + processedRequestsAmount);
				}
			}
			finally
			{
				listener.Stop();
				Console.WriteLine("Server stopped! Press ENTER to close application...");
				Console.ReadLine();
			}
		}
		private async Task AcceptClientsAsync(TcpListener listener)
		{
			while (true)
			{
				try
				{
					TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
					StartClientListenerAsync(client);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
		private async Task StartClientListenerAsync(TcpClient client)
		{
			using (client)
			{
				var buf = new byte[1024];
				NetworkStream stream = client.GetStream();
				lock (connectedUsers)
				{
					connectedUsers.Add(stream);
				}
				Console.WriteLine(connectedUsers.Count + " users connected!");
				while (true)
				{
					try
					{
						await RecieveMessageAsync(stream, buf).ConfigureAwait(false);
					}
					catch (Exception ex)
					{
						break;
					}
				}
				connectedUsers.Remove(stream);
				Console.WriteLine("User disconnected.");
			}
		}
		private async Task RecieveMessageAsync(NetworkStream stream, byte[] readBuffer)
		{
			int totalAmountRead = 0;
			// read header (length, 2 bytes total)
			while (totalAmountRead < 2)
			{
				totalAmountRead += await stream.ReadAsync(readBuffer, totalAmountRead, 2 - totalAmountRead).ConfigureAwait(false);
			}
			short totalLength = BitConverter.ToInt16(readBuffer, 0);
			// read rest of the message
			while (totalAmountRead < totalLength)
			{
				totalAmountRead += await stream.ReadAsync(readBuffer, totalAmountRead, totalLength - totalAmountRead).ConfigureAwait(false);
			}
			await SendToAll(readBuffer, totalLength).ConfigureAwait(false);
		}
		private async Task SendToAll(byte[] buffer, short totalLength)
		{
			List<Task> tasks = new List<Task>(connectedUsers.Count);
			if (processedRequestsAmount == 0)
			{
				sw.Start();
			}
			foreach (NetworkStream stream in connectedUsers)
			{
				tasks.Add(stream.WriteAsync(buffer, 0, buffer.Length));
			}
			await Task.WhenAll(tasks).ConfigureAwait(false);
			processedRequestsAmount++;
			if (processedRequestsAmount == 1000)
			{
				sw.Stop();
				Console.WriteLine("Average time for sending 400 messages is {0} ms", sw.Elapsed.TotalMilliseconds / 1000.0);
			}
		}
	}
