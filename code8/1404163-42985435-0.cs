    var claims = new Dictionary<string, object>()
    {
        { "userID", "xxx"  },
        // other claims
    };
    var certificate = new X509Certificate2("publiccert.p12", "passcode");
    string token = SignJWTWithCert(certificate, claims);
    private static string SignJWTWithCert(X509Certificate2 cert, object claims)
    {
            var header = new { alg = "ES256", typ = "JWT" };
            byte[] headerBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header, Formatting.None));
            byte[] claimsBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(claims, Formatting.None));
            using (ECDsa ecdsa = cert.GetECDsaPrivateKey())
            {
                if (ecdsa == null)
                    throw new ArgumentException("Cert must have an ECDSA private key", nameof(cert));
                var payload = Base64UrlEncode(headerBytes) + "." + Base64UrlEncode(claimsBytes);
                var signature = ecdsa.SignData(Encoding.UTF8.GetBytes(payload), HashAlgorithmName.SHA256);
                return payload + "." + Base64UrlEncode(signature);
            }
    }
