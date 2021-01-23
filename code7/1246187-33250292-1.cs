	public void UpdateTextBox(string input, int numberofdirsleft)
	{
		if (InvokeRequired)
		{
			textBox1.BeginInvoke(new NameCallBack(UpdateTextBox), new object[] { input, numberofdirsleft });
		}
		else
		{
			textBox1.Text = numberofdirsleft.ToString() + " " + input;
		}
	}
