		using System.Net.NetworkInformation;
		private static bool CanPing(string address)
		{
			Ping myping = new Ping();
			try
			{
				PingReply reply = myping.Send(address, 2000);
				
				if (reply == null) 
					return false;
				return (reply.Status == IPStatus.Success);
			}
			catch (PingException e)
			{
				return false;
			}
		}
	
