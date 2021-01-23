    public class AuthenticatedClient : HttpClient
    {
        public AuthenticatedClient()
        {
            string password = ConfigurationManager.AppSettings["Password"];
            string userName = ConfigurationManager.AppSettings["UserName"];
            string encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(userName + ":" + password));
            BaseAddress = new Uri("http://url");
            DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
	
