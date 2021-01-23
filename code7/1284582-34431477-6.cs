		public static bool PingCheck(string host, int echonum, out double approximateTime) 
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
					approximateTime = 0.0;
					return false;
				}
			}
		
            // at least, one of them should be double to avoid integer division
			approximateTime = (double)totaltime / echonum;
			return true;
		}
		
		private void buttonX1_Click(object sender, EventArgs e)
		{
			double appTime;
			if (PingCheck("8.8.8.", 1, out appTime))
			{
				richTextBox1.Text += appTime.ToString("F2") + Environment.NewLine;
			} else {
				richTextBox1.Text += "the connectin is not available";
			}
		}
