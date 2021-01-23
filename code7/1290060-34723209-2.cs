        public void EAPAsync()
        {
            var webClient = new WebClient();
            webClient.DownloadStringAsync(new Uri("http://www.google.com"));
            webClient.DownloadStringCompleted += webClientDownloadStringCompleted;
        }
        void webClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // use e.Result
            Console.WriteLine("download completed callback.");
        }
