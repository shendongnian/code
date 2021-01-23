    var block = new ActionBlock<string>(async url => 
    {
        Uri uri = new Uri(url);
        string filename = System.IO.Path.GetFileName(uri.LocalPath);
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.GetAsync(url))
        using (HttpContent content = response.Content)
        {
           // ... Read the string.
           using (var fileStream = new FileStream(config.M_F_P + filename, FileMode.Create, FileAccess.Write))
           {
               await content.CopyToAsync(fileStream);
           }
        }
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 } );
    foreach (var url in urls)
    {
        block.Post(url);
    }
    
