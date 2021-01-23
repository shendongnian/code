        private static Task<Dictionary<string, string>> GetUrls(string[] urls)
        {
            var tsc = new TaskCompletionSource<Dictionary<string, string>>();
            var subTasks = urls.ToDictionary(
                url => url,
                url =>
                {
                    using (var wc = new WebClient())
                    {
                        return wc.DownloadStringTaskAsync(url);
                    }
                }
                );
            Task.WhenAll(subTasks.Values).ContinueWith(allTasks =>
            {
                var actualResult = subTasks.ToDictionary(
                    task => task.Key,
                    task => task.Value.Result
                    );
                tsc.SetResult(actualResult);
            });
            return tsc.Task;
        }
