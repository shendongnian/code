    public async Task ProcessBatchAsync()
    {
      CreateConnection();
      List<string> items = new List<string>();
      var tasks = items.Select(item => ProcessItemAsync(item));
      await Task.WhenAll(tasks);
    }
    private async Task ProcessItemAsync(string item)
    {
      var result = await DownloadItemAsync(item);
      //do more processing
    }
