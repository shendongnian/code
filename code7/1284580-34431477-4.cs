		public static string PingCheck(string host, int echonum) 
		{
			long totaltime = 0;
			int timeout = 120;
			Ping pingsender = new Ping();
		
			for (int i = 0; i < echonum; i++)
			{
				PingReply replay = pingsender.Send(host, timeout);
				if (replay.Status == IPStatus.Success)
				{
					totaltime += replay.RoundtripTime;
				} 
				else 
				{
					return "the connectin is not available";
				}
			}
		
			return (totaltime / echonum).ToString("F2");        
		}
		
    However, for me it seems to be incorrect in terms of OOP. Your method returns formatted number or error message. It is pretty inobvious and inconvenient.
