    class MyWebClient : WebClient
    {
        //...
        private readonly string m_Uri;
        private readonly string m_Login;
        private readonly string m_Password;
        public MyWebClient(string url, string login, string password)
        {
            m_Password = password;
            m_Login = login;
            m_Uri = url;
        }
        public async Task LogIn()
        {
            var data = new NameValueCollection
            {
                {"username", m_Login},
                {"password", m_Password}
            };
            await UploadValuesTaskAsync(new Uri(m_Uri), data);
        }
        //...
    }
