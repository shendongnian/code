	private StringBuilder trackInfo;
	private bool track1Complete = false;
	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '?' && !track1Complete)
		{
			trackInfo.Append(e.KeyChar);
		}
		else if (e.KeyChar == '?' && !track1Complete)
		{
			trackInfo.Append(e.KeyChar);
			trackInfo.AppendLine();
			track1Complete = true;
		}
		else if (e.KeyChar != '?' && track1Complete)
		{
			trackInfo.Append(e.KeyChar);
		}
		else if (e.KeyChar == '?' && track1Complete)
		{
			trackInfo.Append(e.KeyChar);
            trackInfo.AppendLine();
			sendTrackInfo();
		}
	}
	
