    private async Task Doit(string s)
    {
      WebClient client = new WebClient();
      for (int i = 0; i < 10; i++)
      {
        await client.DownloadDataTaskAsync(uri);
        textBox1.Text += s + "\r\n";
        this.Update();//textBox1.
      }
    }
