    Uri url = new Uri("http://icecast6.play.cz/radio1-128.mp3"); 
    HttpResponseMessage response = await httpClient.GetAsync(
                url,
                HttpCompletionOption.ResponseHeadersRead);
    IInputStream inputStream = await response.Content.ReadAsInputStreamAsync(); 
    try 
    { 
    ulong totalBytesRead = 
    IBuffer buffer = new Windows.Storage.Streams.Buffer(100000);
     while (buffer.Length > 0);
     {
         uffer = await inputStream.ReadAsync(
                 buffer,
                 buffer.Capacity,
                 InputStreamOptions.Partial);
    //
    // Some stuff here...
          totalBytesRead += buffer.Length;
          Debug.WriteLine(buffer.Length + " " + totalBytesRead);
    } 
    Debug.WriteLine(totalBytesRead);
