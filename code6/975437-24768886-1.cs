    static void Main()
    {
        var task = DownloadFileAsync("http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0");
        task.Wait();
                   
    }
    
    static async Task DownloadFileAsync(string url)
    {
        HttpClient client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
    
        HttpResponseMessage response = await client.GetAsync(url);
            
        // Get the file name from the content-disposition header.
        // This is nasty because of bug in .net: http://stackoverflow.com/questions/21008499/httpresponsemessage-content-headers-contentdisposition-is-null
        string fileName = response.Content.Headers.GetValues("Content-Disposition")
            .Select(h => Regex.Match(h, @"(?<=filename=).+$").Value)
            .FirstOrDefault()
            .Replace('/', '_');
    
        using (FileStream file = File.Create(fileName))
        {
            await response.Content.CopyToAsync(file);
        }
    }
