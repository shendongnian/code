    //Helper to get SAML token from STS
    public static SecurityToken GetSamlToken(string realm, string trustUrl, string userName, string password, string keyType, SecurityToken actAsToken = null)
    {
        var factory = new WSTrustChannelFactory(
            //You will need to use WindowsWSTrustBinding here I think
            new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
            trustUrl
        );
    
        factory.TrustVersion = TrustVersion.WSTrust13;
    
        //Here you would use Windows credentials instead of username/password
        factory.Credentials.UserName.UserName = userName;
        factory.Credentials.UserName.Password = password;
    
        var rst = new RequestSecurityToken
        {
            RequestType = RequestTypes.Issue,
            TokenType = TokenTypes.Saml2TokenProfile11,
            KeyType = keyType, //I used KeyTypes.Bearer here
            AppliesTo = new EndpointReference(realm)
        };
    
        if (actAsToken != null)
        {
            rst.ActAs = new SecurityTokenElement(actAsToken);
        }
    
        var token = factory.CreateChannel().Issue(rst);
    
        return token;
    }
    var token = GetSamlToken(...);
    var binding = new WS2007FederationHttpBinding(WSFederationHttpSecurityMode.Message); 
    binding.Security.Message.EstablishSecurityContext = false;
    binding.Security.Message.IssuedKeyType = SecurityKeyType.BearerKey;
    
    var factory = new ChannelFactory<IService1>(binding, new EndpointAddress(serviceEndpoint));
    
    ChannelFactoryOperations.ConfigureChannelFactory<IService1>(factory);
    
    factory.Credentials.SupportInteractive = false;
    factory.Credentials.UseIdentityConfiguration = true;
         
    var channel = factory.CreateChannelWithIssuedToken<IService1>(token);
    channel.CallSomeServiceMethod();
