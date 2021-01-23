    public async Task CheckInternetAsync()
    {
        Ping myPing = new Ping();
        try
        {
            var pingReply = await myPing.SendPingAsync("google.com", 3000, new byte[32], new PingOptions(64, true));
    		if (pingReply.Status == IPStatus.Success)
    		{
    			this.iconeConnexion = WindowsFormsApplication1.Properties.Resources.green;
    		}
        }
        catch (Exception e)
        {
    		this.iconeConnexion = WindowsFormsApplication1.Properties.Resources.red;
        }
    }
