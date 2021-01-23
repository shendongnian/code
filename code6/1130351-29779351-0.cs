        static Lazy<Dictionary<string, X509Certificate2>> Certificates = new Lazy<Dictionary<string, X509Certificate2>>( FetchGoogleCertificates );
        static Dictionary<string, X509Certificate2> FetchGoogleCertificates()
        {
            using (var http = new HttpClient())
            {
                var json = http.GetStringAsync( "https://www.googleapis.com/oauth2/v1/certs" ).Result;
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>( json );
                return dictionary.ToDictionary( x => x.Key, x => new X509Certificate2( Encoding.UTF8.GetBytes( x.Value ) ) );
            }
        }
        JwtSecurityToken ValidateIdentityToken( string idToken )
        {
            var token = new JwtSecurityToken( idToken );
            var jwtHandler = new JwtSecurityTokenHandler();
            var certificates = Certificates.Value;
            try
            {
                // Set up token validation
                var tokenValidationParameters = new TokenValidationParameters();
                tokenValidationParameters.ValidAudience = _clientId;
                tokenValidationParameters.ValidIssuer = "accounts.google.com";
                tokenValidationParameters.IssuerSigningTokens = certificates.Values.Select( x => new X509SecurityToken( x ) );
                tokenValidationParameters.IssuerSigningKeys = certificates.Values.Select( x => new X509SecurityKey( x ) );
                tokenValidationParameters.IssuerSigningKeyResolver = ( s, securityToken, identifier, parameters ) =>
                {
                    return identifier.Select( x =>
                    {
                        if (!certificates.ContainsKey( x.Id ))
                            return null;
                        return new X509SecurityKey( certificates[ x.Id ] );
                    } ).First( x => x != null );
                };
                
                SecurityToken jwt;
                var claimsPrincipal = jwtHandler.ValidateToken( idToken, tokenValidationParameters, out jwt );
                return (JwtSecurityToken)jwt;
            }
            catch (Exception ex)
            {
                _trace.Error( typeof( GoogleOAuth2OpenIdHybridClient ).Name, ex );
                return null;
            }
        }
 
