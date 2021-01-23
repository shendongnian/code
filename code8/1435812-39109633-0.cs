    private async void btn_download_Click(object sender, EventArgs e)
    {
        .
        .
        .
        var token = cancelTokenSource.Token;
        try
        {
            await DownloadMultipleFilesAsync(old_json, );
            Console.WriteLine("Download completed.");
        }
        catch(OperationCanceledException ex)
        {
            //If something other than our token caused the cancel bubble up the exception.
            if(ex.CancellationToken != token)
                throw;
        }
    }
    private async Task DownloadMultipleFilesAsync(List<media> doclist, CancellationToken token)
    {
        var token = cancelTokenSource.Token;
        await Task.WhenAll(doclist.Select(doc => DownloadFileAsync(doc, token), token));
        btn_download.Enabled = true;
    }
    private async Task DownloadFileAsync(media media, CancellationToken token)
    {
        .
        .
        .
        Console.WriteLine(media.no + media_ext + " started.");
        webClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        using(token.Register(() => webClient.CancelAsync()))
        {
            await webClient.DownloadFileTaskAsync(new Uri(media.url), @downloadToDirectory);
        }
        //I don't know if the await will throw, so I put this here to be safe.
        token.ThrowIfCancellationRequested();
        Console.WriteLine(media.no + media_ext + " finished.");
        .
        .
        .
    }
