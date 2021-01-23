    public delegate T ParseToObject<T>(string response);
    public class ServiceConnector : IServiceConnector
    {
        public string LogoffUrl { get; set; }
        public bool SupportRetry { get; set; }        
        private WebClient _client;
        public ServiceConnector()
        {
        }
        public T GetResponse<T>(string requestUrl, ParseToObject<T> parsingMethod)
        {
            string response = __getResponse(requestUrl);
            return parsingMethod(response);
        }     
        private string __getResponse(string requestUrl)
        {
            string serviceResponse = string.Empty;
            try
            {
                __initializeWebClient();
                Logger.Current.LogInfo(string.Format("Sending request with URL {0}", requestUrl));
                serviceResponse = _client.DownloadString(requestUrl);
            }
            catch (Exception ex)
            {
                if (ex.Message != null) 
                {
                Logger.Current.LogException(string.Format("Exception during OvidWS request {0} ", requestUrl), ex); 
                    _client = null;
                }
              //Sample implementation only, you could throw the exception up based on your domain needs
            }
            return serviceResponse;
        }
        private void __initializeWebClient()
        {
            if (_client == null)
                _client = new WebClient();
        }
    }
