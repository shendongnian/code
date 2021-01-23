    private async void Button_Click(object sender, EventArgs e)
    {
        // Disabling the button ensures that it's not pressed
        // again while the first request is still in flight.
        materialRaisedButton1.Enabled = false;
        try
        {
            using (WebClient client = new WebClient())
            {
                // Async downloads:
                string content1 = await client.DownloadStringTaskAsync("<your URL here>");
                string content2 = await client.DownloadStringTaskAsync("<your URL here>");
                string content3 = await client.DownloadStringTaskAsync("<your URL here>");
                // Update all textboxes at the same time.
                textBox1.Text = content1;
                textBox2.Text = content2;
                textBox3.Text = content3;
            }
        }
        finally
        {
            materialRaisedButton1.Enabled = true;
        }
    }
