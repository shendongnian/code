    public class ConnectionManager
    {
        private DropNetClient _client;
        public string GetConnectUrl(DropNetClient client, string callbackurl)
        {
            _client = client;
            var url = _client.BuildAuthorizeUrl(callbackurl);
            return url;
        }
        public DropNetClient Connect()
        {
            _client = new DropNetClient("token", "secret");
            _client.GetToken();
            return _client;
        }
        public Dictionary<string, string> GetAccessToken(string tok, string secret)
        {
         
            _client = new DropNetClient("token", "secret", tok, secret);
            var token = _client.GetAccessToken();
            var dic = new Dictionary<string, string> {{"token", token.Token}, {"secret", token.Secret}};
            return dic;
        }
        public DropNetClient Connect(TokenAndSecretModel model)
        {
            _client = new DropNetClient("token", "secret", model.Token, model.Secret);
            var info = _client.AccountInfo();
            return _client;
        }
    }
