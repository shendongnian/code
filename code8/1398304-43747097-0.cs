    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
    {
        var entry = archive.CreateEntry("MyFileName.txt");
        using (var streamWriter = new StreamWriter(entry.Open()))
        {
            streamWriter.Write("It was the best of times, it was the worst of times...");
        }
    }
    //ADD THIS LINE
    memoryStream.Position = 0;    
    response.Content = new StreamContent(memoryStream);
