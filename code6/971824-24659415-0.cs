    public class DownloadResult { /*...*/ }
    public Task<DownloadResult> DownloadFileAsync(string path) { /*...*/ }
    public IObservable<DownloadResult> DownloadFiles(int maxConcurrent, string[] paths)
    {
        return paths
            .Select(path => Observable.FromAsync(() => DownloadFileAsync(path)))
            .Merge(maxConcurrent: maxConcurrent);
    }
