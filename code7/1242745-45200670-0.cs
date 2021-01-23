    public class AzureKeyVaultClient
    {
        
        public string GetSecret(string name, string vault)
        {
            var client = new RestClient($"https://{vault}.vault.azure.net/");
            client.Authenticator = new AzureAuthenticator($"https://vault.azure.net");
            var request = new RestRequest($"secrets/{name}?api-version=2016-10-01");
            request.Method = Method.GET;
            
            var result = client.Execute(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                Trace.TraceInformation($"Unable to retrieve {name} from {vault} with response {result.Content}");
                var exception =  GetKeyVaultErrorFromResponse(result.Content);
                throw exception;
                
            }
            else
            {
                return GetValueFromResponse(result.Content);
            }
        }
        public string GetValueFromResponse(string content)
        {
            
                var result = content.FromJson<keyvaultresponse>();
                return result.value;
           
        }
        public Exception GetKeyVaultErrorFromResponse(string content)
        {
            try
            {
                var result = content.FromJson<keyvautlerrorresponse>();
                var exception = new Exception($"{result.error.code} {result.error.message}");
                if(result.error.innererror!=null)
                {
                    var innerException = new Exception($"{result.error.innererror.code} {result.error.innererror.message}");
                }
                return exception;
            }
            catch(Exception e)
            {
                return e;
            }
        }
        class keyvaultresponse
        {
            public string value { get; set; }
            public string contentType { get; set; }
        }
        class keyvautlerrorresponse
        {
            public keyvaulterror error {get;set;}
        }
        class keyvaulterror
        {
            public string code { get; set; }
            public string message { get; set; }
            public keyvaulterror innererror { get; set; }
        }
        class AzureAuthenticator : IAuthenticator
        {
            private string _authority;
            private string _clientId;
            private string _clientSecret;
            private string _resource;
            public AzureAuthenticator(string resource)
            {
                _authority = WebConfigurationManager.AppSettings["azure:Authority"];
                _clientId = WebConfigurationManager.AppSettings["azure:ClientId"];
                _clientSecret = WebConfigurationManager.AppSettings["azure:ClientSecret"];
                _resource = resource;
            }
            public AzureAuthenticator(string resource, string tennant, string clientid, string secret)
            {
                //https://login.microsoftonline.com/<tennant>/oauth2/oken
                _authority = authority;
                //azure client id (web app or native app
                _clientId = clientid;
                //azure client secret
                _clientSecret = secret;
                //vault.azure.net
                _resource = resource;
            }
            public void Authenticate(IRestClient client, IRestRequest request)
            {
                var token = GetS2SAccessTokenForProdMSA().AccessToken;
                //Trace.WriteLine(String.Format("obtained bearer token {0} from ADAL and adding to rest request",token));
                request.AddHeader("Authorization", String.Format("Bearer {0}", token));
            }
            public AuthenticationResult GetS2SAccessTokenForProdMSA()
            {
                return GetS2SAccessToken(_authority, _resource, _clientId, _clientSecret);
            }
            private AuthenticationResult GetS2SAccessToken(string authority, string resource, string clientId, string clientSecret)
            {
                var clientCredential = new ClientCredential(clientId, clientSecret);
                AuthenticationContext context = new AuthenticationContext(authority, false);
                AuthenticationResult authenticationResult = context.AcquireToken(
                    resource,
                    clientCredential);
                return authenticationResult;
            }
        }
    }
