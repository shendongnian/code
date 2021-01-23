	private async void Start_Stop_Click(object sender, EventArgs e)
	{
		double x;
		while (true)
		{
			x = x + 0.00522222222222222222222222222222;
			y.Text = x.ToString();
			await Task.Delay(100);
		}
	}
