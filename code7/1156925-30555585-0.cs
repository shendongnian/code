	private async void connectButton_Click(object sender, EventArgs e)
	{
		statusLabel.Text = "Connecting...";
		statusLabel.ForeColor = Color.Green;
		serverNameBox.Enabled = false;
		databaseNameBox.Enabled = false;
		connectButton.Enabled = false;
		conn = new SqlConnection("server=" + serverNameBox.Text + ";Trusted_Connection=yes;database=" + databaseNameBox.Text + ";connection timeout=3");
		try
		{
			await conn.OpenAsync();
		}
		catch (Exception ex)
		{
			statusLabel.Text = "Connection Failed";
			statusLabel.ForeColor = Color.DarkRed;
			MessageBox.Show("Connection Failed. Error message below:\n" + ex.Message);
			serverNameBox.Enabled = true;
			databaseNameBox.Enabled = true;
			connectButton.Enabled = true;
			return;
		}
		statusLabel.Text = "Connected Successfully";
		statusLabel.ForeColor = Color.DarkGreen;
		serverNameBox.Enabled = true;
		connectButton.Enabled = true;
		conn.Close();
		UpdateTraders();      // This might need the async treatment too
		UpdateTransactions(); // This might need the async treatment too
	}
