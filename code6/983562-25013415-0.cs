    private async void button1_Click(object sender, EventArgs e)
    {
        string result = await SomeLongRunningMethod("www.stackoverflow.com");
        
        // LongRunningMethod has completed.
        ....
    }
    public Task<string> SomeLongRunningMethod(string uri)
    {
        // Example
        return WebClient.DownloadStringAsync(new Uri(uri));
    }
