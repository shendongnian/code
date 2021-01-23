	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		int eventIndex = (int)e.UserState;
		if (eventIndex == 0) // upload status.
		{
			toolStripStatusLabel1.Text = stringProgressReport[0];
		}
		else if (eventIndex == 1) // obj.Status
		{
			toolStripStatusLabel2.Text = stringProgressReport[1];
		}
		else if (eventIndex == 2) // mb sent so far
		{
			// ??? where do you want to put this ??? = stringProgressReport[2];
		}
		else if (eventIndex == 3) // percent complete
		{
			toolStripProgressBar1.Value = Int32.Parse(stringProgressReport[3]);
		}
		else
		{
			throw new Exception("Invalid event index: " + eventIndex);
		}
	}
