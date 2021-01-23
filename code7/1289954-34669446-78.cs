		static void loopConnect(int noOfRetry, int attemptPeriodInSeconds) {
			int attempts = 0;
			while (!clientSocket.Connected && attempts < noOfRetry) {
				try {
					++attempts;
					IAsyncResult result = clientSocket.BeginConnect(IPAddress.Parse(SERVER_IP), PORT_NO, endConnect, null);
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
