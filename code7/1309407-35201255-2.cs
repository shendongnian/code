        private static IEnumerable<string> GetUrls()
        {
            return new[] { "https://stackoverflow.com/", "http://www.google.com/" };
        }
        internal async Task Fetch()
        {
            var urls = GetUrls();
            var tasks = urls.Select(DoWorkAsync);
            await Task.WhenAll(tasks);
        }
        internal Task DoWorkAsync(string url)
        {
            // TODO: Implement actual work on the URL in an async manner.
            return Task.FromResult(url);
        }  
