    private class MyWebClient : WebClient
    {
        public int Timeout { get; set; }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = Timeout;
            ((HttpWebRequest) w).ReadWriteTimeout = Timeout;
            return w;
        }
    }
