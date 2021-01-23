        public async Task<string> DownloadAsync(string url)
        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }
        public void DownloadAsyncHandler()
        {
            //DownloadAsync("http://www.google.com");
        }
