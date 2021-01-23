        public string TestNoneAsync()
        {
            var webClient = new WebClient();
            return webClient.DownloadString("http://www.google.com");
        }
