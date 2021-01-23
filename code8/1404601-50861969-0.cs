    public class ExtendedWebClient : System.Net.WebClient
    {
        X509Certificate2 _certificate;
        
        public ExtendedWebClient() : base() { }
        public ExtendedWebClient(X509Certificate2 certificate) : base()
        {
            _certificate = certificate;
        }
    
        protected override WebRequest GetWebRequest(Uri address)
        {
            // Base method creates HttpWebRequest and sets other needed stuff like POST method or authentication/authorization headers.
            HttpWebRequest request = (HttpWebRequest)base.Create(address);
            if(_certificate!=null && address.Schema=="https")
                request.ClientCertificates.Add(_certificate);            
            return request;
        }
    }
