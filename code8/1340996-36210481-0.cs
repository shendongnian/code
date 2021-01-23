    static async void GetFilePart(string hostrUri)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(hostrUri)
        };
    
        var request = new HttpRequestMessage(HttpMethod.Get, "/Home/DownloadFilePart/?fileName=Test.txt");
        var responseMessage = await httpClient.SendAsync(request);
        var byteArray = await responseMessage.Content.ReadAsByteArrayAsync();
        var fileToWriteTo = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Temp\\Test.txt";
    
        using (var fileStream = new FileStream(fileToWriteTo, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            //copy the content from response to filestream
            fileStream.Write(byteArray, 0, byteArray.Length);
        }
    }
