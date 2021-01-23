	public static double PingCheck(string host, int echonum) 
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
		}
		
		return totaltime / echonum;        
	}
	private void buttonX1_Click(object sender, EventArgs e)
	{
		var pingCheckResult = PingCheck("8.8.8.", 1);
		
		richTextBox1.Text += pingCheckResult > 0 
            ? $"{pingCheckResult}\n" // C#6 syntax
            : "the connectin is not available";
	}
