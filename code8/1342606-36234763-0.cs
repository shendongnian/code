    [DataContract]
    public clas OAuthToken
    {
        [DataMember(Name="access_token")]
        public string AccessToken{set;get;}
        [DataMember(Name="token_type)]
        public string TokenType{set;get;}
