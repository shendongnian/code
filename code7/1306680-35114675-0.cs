    /// <summary>The OAuth access token</summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken;
        /// <summary>The type of the OAuth token</summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType;
        /// <summary>The date when the OAuth token will expire</summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn;
        /// <summary>The OAuth refresh token</summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken;
        /// <summary>The scope of the OAuth token</summary>
        [JsonProperty(PropertyName = "scope")]
        public string Scope;
