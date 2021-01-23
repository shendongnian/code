	private bool CanPing(string url)
	{
		try
		{
			return new Ping().Send(url).Status == IPStatus.Success;
		}
		catch (PingException)
		{
			return false;
		}
	}
