    private async void Button_Click(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            textBox1.Text = await client.DownloadStringTaskAsync("<your URL here>");
            textBox2.Text = await client.DownloadStringTaskAsync("<your URL here>");
            textBox3.Text = await client.DownloadStringTaskAsync("<your URL here>");
        }
    }
