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
			} else {
                return 0.0;
            }
		}
		
        // at least, one of them should be double to avoid integer division
		return (double)totaltime / echonum; 
	}
	private void buttonX1_Click(object sender, EventArgs e)
	{
		var pingCheckResult = PingCheck("8.8.8.", 1);
		
		richTextBox1.Text += pingCheckResult > 0 
            ? pingCheckResult.ToString("F2") + Environment.NewLine 
            : "the connectin is not available";
	}
