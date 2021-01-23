    BootstrapContext context = ClaimsPrincipal.Current.Identities.First().BootstrapContext as BootstrapContext;
    
    var factory = new WSTrustChannelFactory(
        new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential), _trustUrl);
    factory.TrustVersion = TrustVersion.WSTrust13;
    
    factory.Credentials.UserName.UserName = "webappaccount";
    factory.Credentials.UserName.Password = "P@ssword";
    
    var rst = new RequestSecurityToken
    {
        RequestType = RequestTypes.Issue,
        KeyType = KeyTypes.Bearer,
        AppliesTo = new EndpointReference(_realm),
        ActAs = new SecurityTokenElement(context.SecurityToken)
    };
    
    var token = factory.CreateChannel().Issue(rst) as GenericXmlSecurityToken;
    
    var client = new HttpClient
    {
        BaseAddress = _baseAddress
    };
    
    client.SetToken("SAML", token.TokenXml.OuterXml);
    
    var response = client.GetAsync("api/values").Result;
