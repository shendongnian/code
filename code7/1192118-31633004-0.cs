	private async void button1_Click(object sender, EventArgs e)
	{
		textBox1.Enabled = false;
		string url = textBox1.Text;
		using (WebClient client = new WebClient())
		{
			textBox2.Text = await Task.Run(() => client.DownloadString(url));
		}
	}
