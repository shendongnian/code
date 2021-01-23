    private void buttonGetHTML_Click(object sender, EventArgs e)
    {
        var url = textBoxUrl.Text;
        Task.Run(() => Download(url)).ContinueWith((Download) => { htmlContent.Text = Download.Result; },  TaskScheduler.FromCurrentSynchronizationContext));
    }
    private string Download(string url)
    {
        using (WebClient client = new WebClient())
        {
            string context = client.DownloadString(url);
            return context;
        }
    }
