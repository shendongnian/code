    async Task AccessTheWebAsync(CancellationToken ct)
    {
      HttpClient client = new HttpClient();
      // Make a list of web addresses.
      List<string> urlList = SetUpURLList();
      // ***Create a query that, when executed, returns a collection of tasks.
      IEnumerable<Task> downloadTasksQuery =
            from url in urlList select DownloadAndUpdateAsync(url, client, ct);
      // ***Use ToList to execute the query and start the tasks. 
      List<Task> downloadTasks = downloadTasksQuery.ToList();
      await Task.WhenAll(downloadTasks);
    }
    async Task DownloadAndUpdateAsync(string url, HttpClient client, CancellationToken ct)
    {
      var length = await ProcessURLAsync(url, client, ct);
      resultsTextBox.Text += String.Format("\r\nLength of the download:  {0}", length);
    }
    async Task<int> ProcessURLAsync(string url, HttpClient client, CancellationToken ct)
    {
      // GetAsync returns a Task<HttpResponseMessage>. 
      HttpResponseMessage response = await client.GetAsync(url, ct);
      // Retrieve the website contents from the HttpResponseMessage.
      byte[] urlContents = await response.Content.ReadAsByteArrayAsync();
      return urlContents.Length;
    }
