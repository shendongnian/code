	private void MyThreadFunc()
	{
		// do something here
		Thread.Sleep(10000);
		// update the label:
		if (label1.InvokeRequired)
			Invoke(UpdateLabel);
		else
			UpdateLabel();
	}
	private void UpdateLabel()
	{
		label1.Text = "Something was finished.";
	}
