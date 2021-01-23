    private static async Task<string[]> searchForLinksAsync()
    {
      string url = "http://www.xxxx.pl/xxxx/?action=xxxx&id=";
      var tasks = Enumerable.Range(0, 2500).Select(i => checkAvailableAsync(url + i));
      var results = await Task.WhenAll(tasks);
      var listOfUrls = results.Where(x => x != null).ToArray();
      Console.WriteLine(listOfUrls.Length);
      Console.ReadLine();
    }
