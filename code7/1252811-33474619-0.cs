    private static List<string> listOfUrls = new List<string>();
    private static void searchForLinks()
    {
        string url = "http://www.xxxx.pl/xxxx/?action=xxxx&id=";
        int numberOfConcurrentDownloads = 10;
        for (int i = 0; i < 2500; i += numberOfConcurrentDownloads)
        {
            List<Task> allDownloads = new List<Task>();
            for (int j = i; j < i + numberOfConcurrentDownloads; j++)
            {
                string tmp = url;
                tmp += Convert.ToString(i);
                allDownloads.Add(checkAvaible(tmp));
            }
            Task.WaitAll(allDownloads.ToArray());
        }
        Console.WriteLine(listOfUrls.Count());
        Console.ReadLine();
    }
    private static async Task checkAvaible(string url)
    {
        using (WebClient client = new WebClient())
        {
            string htmlCode = await client.DownloadStringTaskAsync(new Uri(url));
            if (htmlCode.IndexOf("Brak takiego obiektu w naszej bazie!") == -1)
            {
                lock (listOfUrls)
                {
                    listOfUrls.Add(url);
                }
            }
        }
    }
