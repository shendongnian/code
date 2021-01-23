    public YourClass
    {
        private CookieContainer Cookies;
        public YourClass()
        {
            this.Cookies= new CookieContainer(); 
        }
        public void SendAndReceive()
        {
        	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(...);
            ....
			request.UserAgent = agent;
			request.Method = "GET";
			request.ContentType = "text/html";
			request.CookieContainer = this.Cookies;
            ....
            this.Cookies = (HttpWebResponse)request.GetResponse().Cookies;
        }
    }
