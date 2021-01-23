	private void Form1_KeyDown(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
			case Keys.Escape:
				cancallation.Cancel();
				break;
		}
	}
	private CancellationTokenSource cancallation = new CancellationTokenSource();
	private void button1_Click(object sender, EventArgs e)
	{
		Task.Run(() =>
		{
			while (...)
			{
				for (...)
				{
					cancallation.Token.ThrowIfCancellationRequested();
				}
			}
		}, cancallation.Token);
	}
	private void Form1_FormClosed(object sender, FormClosedEventArgs e)
	{
		if (cancallation.IsCancellationRequested == false)
		{
			cancallation.Cancel();
		}
	}
