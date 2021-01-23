        protected void Application_Start()
        {
            // ...
            ThreadPool.QueueUserWorkItem(o => PingMyself());
        }
        private static void PingMyself()
        {
            var webClient = new WebClient();
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMinutes(1));
                webClient.DownloadString("http://my.public.address.com");
            }
        }
