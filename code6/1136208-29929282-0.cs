    public class MyPeriodicWatcher 
    {
        private readonly string _watchPath;
        private readonly string _searchMask;
        private readonly Func<string, string> _commonPrefixFetcher;
        private readonly Action<FileInfo, FileInfo> _pairProcessor;
        private readonly TimeSpan _checkInterval;
        private readonly CancellationToken _cancelToken;
        public MyPeriodicWatcher(
            string watchPath,
            string searchMask,
            Func<string, string> commonPrefixFetcher,
            Action<FileInfo, FileInfo> pairProcessor,
            TimeSpan checkInterval,
            CancellationToken cancelToken)
        {
            _watchPath = watchPath;
            _searchMask = string.IsNullOrWhiteSpace(searchMask) ? "*.zip" : searchMask;
            _pairProcessor = pairProcessor;
            _commonPrefixFetcher = commonPrefixFetcher;
            _cancelToken = cancelToken;
            _checkInterval = checkInterval;
        }
        public async Task Watch()
        {
            while (!_cancelToken.IsCancellationRequested)
            {
                try
                {
                    foreach (var file in Directory.EnumerateFiles(_watchPath, _searchMask))
                    {
                        var pairPrefix = _commonPrefixFetcher(file);
                        if (!string.IsNullOrWhiteSpace(pairPrefix))
                        {
                            var match = Directory.EnumerateFiles(_watchPath, pairPrefix + "*.ctl").FirstOrDefault();
                            if (!string.IsNullOrEmpty(match) && !_cancelToken.IsCancellationRequested)
                                _pairProcessor(
                                    new FileInfo(Path.Combine(_watchPath, file)),
                                    new FileInfo(Path.Combine(_watchPath, match)));
                        }
                        if (_cancelToken.IsCancellationRequested)
                            break;
                    }
                    if (_cancelToken.IsCancellationRequested)
                        break;
                    await Task.Delay(_checkInterval, _cancelToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    }
