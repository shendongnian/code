    X509Store certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
    certStore.Open(OpenFlags.ReadOnly);
    X509Certificate2Collection certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, this.OAuthKeyFingerprint, false);
    
    // Get the first cert with the thumbprint
    if (certCollection.Count > 0)
    {
        // header
        var header = new { typ = "JWT", alg = "RS256" };
    
        // claimset
        var times = GetExpiryAndIssueDate();
        var claimset = new
        {
            iss = this.OAuthServiceAccountEmail,
            scope = "https://www.googleapis.com/auth/analytics",
            aud = "https://www.googleapis.com/oauth2/v3/token",
            iat = times[0],
            exp = times[1],
        };
    
        JavaScriptSerializer ser = new JavaScriptSerializer();
    
        // encoded header
        var headerSerialized = ser.Serialize(header);
        var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
        var headerEncoded = Convert.ToBase64String(headerBytes);
    
        // encoded claimset
        var claimsetSerialized = ser.Serialize(claimset);
        var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
        var claimsetEncoded = Convert.ToBase64String(claimsetBytes);
    
        // input
        var input = headerEncoded + "." + claimsetEncoded;
        var inputBytes = Encoding.UTF8.GetBytes(input);
    
        X509Certificate2 tCertificate = certCollection[0];
    
        // signiture
        var rsa = tCertificate.PrivateKey as RSACryptoServiceProvider;
    
        var cspParam = new CspParameters
        {
            KeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName,
            KeyNumber = rsa.CspKeyContainerInfo.KeyNumber == KeyNumber.Exchange ? 1 : 2,
            Flags = CspProviderFlags.UseMachineKeyStore
        };
        var aescsp = new RSACryptoServiceProvider(1024, cspParam) { PersistKeyInCsp = true };
        var signatureBytes = aescsp.SignData(inputBytes, "SHA256");
        var signatureEncoded = Convert.ToBase64String(signatureBytes);
    
        // jwt
        var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;
    
        HttpClient client = new HttpClient();
    
        Dictionary<string, string> post = new Dictionary<string, string>
            {
                {"assertion", jwt},
                {"grant_type", "urn:ietf:params:oauth:grant-type:jwt-bearer"}
            };
    
        FormUrlEncodedContent content = new FormUrlEncodedContent(post);
    
        var uri = "https://www.googleapis.com/oauth2/v3/token";
    
        HttpResponseMessage result = client.PostAsync(uri, content).Result;
        TokenResponse tokenObject = JsonConvert.DeserializeObject<TokenResponse>(result.Content.ReadAsStringAsync().Result);
    
        this.SessionToken = tokenObject.access_token;
    }
    
    certStore.Close();
