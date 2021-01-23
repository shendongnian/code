    private async void Button_Click(object sender, EventArgs e)
    {
        // Disabling the button ensures that it's not pressed
        // again while the first request is still in flight.
        materialRaisedButton1.Enabled = false;
        try
        {
            using (WebClient client = new WebClient())
            {
                // Execute async downloads in parallel:
                Task<string>[] parallelDownloads = new[] {
                    client.DownloadStringTaskAsync("<your URL here>"),
                    client.DownloadStringTaskAsync("<your URL here>"),
                    client.DownloadStringTaskAsync("<your URL here>")
                };
                // Collect results.
                string[] results = await Task.WhenAll(parallelDownloads);
                // Update all textboxes at the same time.
                textBox1.Text = results[0];
                textBox2.Text = results[1];
                textBox3.Text = results[2];
            }
        }
        finally
        {
            materialRaisedButton1.Enabled = true;
        }
    }
