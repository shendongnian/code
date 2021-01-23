    public class PacerClient
    {
        private CookieContainer m_Cookies = new CookieContainer();
        public string Username { get; set; }
        public string Password { get; set; }
        public PacerClient(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public void Connect()
        {
            var client = new RestClient("https://pacer.login.uscourts.gov");
            client.CookieContainer = this.m_Cookies;
            RestRequest request = new RestRequest("/cgi-bin/check-pacer-passwd.pl", Method.POST);
            request.AddParameter("loginid", this.Username);
            request.AddParameter("passwd", this.Password);
    
            IRestResponse response = client.Execute(request);
    
            if (response.Cookies.Count < 1)
            {
                throw new WebException("No cookies returned.");
            }
        }
        public XmlDocument SearchParty(string partyName)
        {
            string requestUri = $"/dquery?download=1&dl_fmt=xml&party={partyName}";
    
            var client = new RestClient("https://pcl.uscourts.gov");
            client.CookieContainer = this.m_Cookies;
    
            var request = new RestRequest(requestUri);
    
            IRestResponse response = client.Execute(request);
    
            if (!String.IsNullOrEmpty(response.Content))
            {
                XmlDocument result = new XmlDocument();
                result.LoadXml(response.Content);
                return result;
            }
            else return null;
        }
    }
