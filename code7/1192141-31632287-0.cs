    private async void button1_Click(object sender, EventArgs e)
    {
        textBox1.Enabled = false;
        string url = textBox1.Text;
		using (var client = new WebClient())
		{
			textBox2.Text = await client.DownloadStringTaskAsync(new Uri(url));
		}
    }
