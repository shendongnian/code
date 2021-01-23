    public async Task RunOperationAsync()
    {
        await Task.WhenAll(
            startDownload(downloadLink, saveTo),
            startDownload(versionLink, versionSaveTo));
        return writeNewVersion();
    }
