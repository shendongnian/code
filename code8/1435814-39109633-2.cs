    private async void btn_download_Click(object sender, EventArgs e)
    {
        .
        .
        .
        var token = cancelTokenSource.Token;
        try
        {
            await DownloadMultipleFilesAsync(old_json, token);
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
        await Task.WhenAll(doclist.Select(doc => DownloadFileAsync(doc, token));
        btn_download.Enabled = true;
    }
    private async Task DownloadFileAsync(media media, CancellationToken token)
    {
        .
        .
        .
        Console.WriteLine(media.no + media_ext + " started.");
        webClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        try
        {
            using(token.Register(() => webClient.CancelAsync()))
            {
                await webClient.DownloadFileTaskAsync(new Uri(media.url), @downloadToDirectory);
            }
        }            
        catch (WebException ex)
        {
            //Raise a OperationCanceledException if the request was canceled, otherwise bubble up the exception.
            if(ex.Status == WebExceptionStatus.RequestCanceled)
                throw new OperationCanceledException(token);
            else
                throw;
        }
        Console.WriteLine(media.no + media_ext + " finished.");
        .
        .
        .
    }
