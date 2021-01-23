    try
    {
        // Get data and signature from unaltered token
        var data = Encoding.UTF8.GetBytes(token.Split('.')[0] + '.' + token.Split('.')[1]);
        var signature = Convert.FromBase64String(token.Split('.')[2]);
        // Get certificate from file
        var x509 = new X509Certificate2(HttpContext.Current.Server.MapPath("~/App_Data/" + ConfigurationManager.AppSettings["CertFileName"]));
        // Verify the data with the signature
        var csp = (RSACryptoServiceProvider)x509.PublicKey.Key;
        if (!csp.VerifyData(data, "SHA256", signature))
        {
            // Signature verification failed; data was possibly altered
            throw new SecurityTokenValidationException("Data signature verification failed. Token cannot be trusted!");
        }
        // strip off signature from token
        token = token.Substring(0, token.LastIndexOf('.') + 1);
        // Convert Base64 encoded token to Base64Url encoding
        token = token.Replace('+', '-').Replace('/', '_').Replace("=", "");
        // Use JwtSecurityTokenHandler to validate the JWT token
        var tokenHandler = new JwtSecurityTokenHandler();
        // Read the JWT
        var parsedJwt = tokenHandler.ReadToken(token);
        // Set the expected properties of the JWT token in the TokenValidationParameters
        var validationParameters = new TokenValidationParameters()
        {
            NameClaimType = "http://wso2.org/claims/enduser",
            AuthenticationType = ((JwtSecurityToken)parsedJwt).Claims.Where(c => c.Type == "http://wso2.org/claims/usertype").First().Value,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = false,
            RequireExpirationTime = true,
            RequireSignedTokens = false,
            //ValidAudience = ConfigurationManager.AppSettings["AllowedAudience"],
            ValidIssuer = ConfigurationManager.AppSettings["Issuer"],
            //IssuerSigningToken = new X509SecurityToken(cert),
            CertificateValidator = X509CertificateValidator.None
        };
        // Set both HTTP Context and Thread principals, so they will be in sync
        HttpContext.Current.User = tokenHandler.ValidateToken(token, validationParameters, out parsedJwt);
        Thread.CurrentPrincipal = HttpContext.Current.User;
        // Treat as ClaimsPrincipal, extract JWT expiration and inject it into request headers
        var cp = (ClaimsPrincipal)Thread.CurrentPrincipal;
        context.Request.Headers.Add("JWT-Expiration", cp.FindFirst("exp").Value);
    }
    catch (SecurityTokenValidationException stvErr)
    {
        // Log error
        if (context.Trace.IsEnabled)
            context.Trace.Write("JwtAuthorization", "Error validating token.", stvErr);
    }
    catch (System.Exception ex)
    {
        // Log error
        if (context.Trace.IsEnabled)
            context.Trace.Write("JwtAuthorization", "Error parsing token.", ex);
    }
