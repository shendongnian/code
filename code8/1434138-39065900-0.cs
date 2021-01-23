	private async void OnTestClicked(object sender, EventArgs e)
	{
		btn.IsEnabled = false;
		var l2 = new double[TESTQ];
		await Task.Run(async () => {
			for (int i = 0; i < TESTQ; i++)
			{
				Device.BeginInvokeOnMainThread(() => labl.Text = "Step " + i);
				l2[i] = (await ManagedNetworkSpeedAsync(true)).Milliseconds;
			}
		});
		foreach (var x in l2)
		{
			System.Diagnostics.Debug.WriteLine(x);
		}
		btn.IsEnabled = true;
	}
