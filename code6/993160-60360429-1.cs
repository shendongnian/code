    /* startup.cs */  services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
                options.ClaimActions.Add(new CustomClaimsFactory(
                                        "userName",
                                        "xxxxx@outlook.com"
                                    )); 
             }
    /*CustomClaimsFactory run method*/ public override void Run(JObject userData, ClaimsIdentity identity, string issuer)
        {
            identity.AddClaim(new Claim(_ClaimType, _ValueType, issuer));
        }
