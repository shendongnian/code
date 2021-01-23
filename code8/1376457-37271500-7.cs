    private async Task LongRunningOperation() {
        string contents;
        using (var fs = File.OpenRead("some file")) {
            using (var reader = new StreamReader(fs)) {
                contents = await reader.ReadToEndAsync();
            }
        }
        var downloadedFile = await new WebClient().DownloadDataTaskAsync("some file url");
    }
