        public string RequestUrl(string reqUrl)
        {
            WebClient client = new WebClient();
            try
            {
                return client.DownloadString(reqUrl);
            }
            catch (Exception e)
            {
                return "" + e;
            }
        }
