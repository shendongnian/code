        var uriBing = new Uri(@"https://mysite.azurewebsites.net/manuals/01-Introduction.pdf");
        try 
        {
            var ManualFile = await DownloadsFolder.CreateFileAsync("ManualFile.pdf", CreationCollisionOption.FailIfExists);
            var cli = new HttpClient();
            var str = await cli.GetInputStreamAsync(uriBing);
            var dst = await ManualFile.OpenStreamForWriteAsync();
            str.AsStreamForRead().CopyTo(dst);
        }
        catch { }
        var success = await Windows.System.Launcher.LaunchUriAsync(uriBing));
    
