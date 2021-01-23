    public abstract class Provider
    {
        private readonly string _accessToken;
        private readonly string _refreshToken;
        private readonly object _jsonMeta;
        protected Provider(TokenProfile profile)
        {
            _accessToken = profile.AccessToken;
            _refreshToken = profile.RefreshToken;
            _jsonMeta = profile.JsonMeta;
        }
        protected JsonMeta ProviderMeta
        {
            get
            {
                return JsonConvert.DeserializeObject<JsonMeta>(_jsonMeta); ;
            }
        }
        protected class JsonMeta { }
    }
