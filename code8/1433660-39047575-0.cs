    private static async Task<bool> Work(int i, string url)
    {
        if (i % 1000 == 0)
            Console.WriteLine(i);
    
        // Must dispose to avoid leaks
        using (var wc = new WebClient())
        {
            await wc.UploadValuesTaskAsync(url, new System.Collections.Specialized.NameValueCollection());
        }
        //await Task.Delay(1);
        return true;
    }
