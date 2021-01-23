    public static string Decode(string token, string key, bool verify)
    {
        var parts = token.Split('.');
        var header = parts[0];
        var payload = parts[1];
        // byte[] crypto = Base64UrlDecode(parts[2]);
        var jwtSignature = parts[2];
    
        var headerJson = Encoding.UTF8.GetString(Base64UrlDecode(header));
        var headerData = JObject.Parse(headerJson);
        var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
        var payloadData = JObject.Parse(payloadJson);
    
        if (verify)
        {
            var bytesToSign = Encoding.UTF8.GetBytes(string.Concat(header, ".", payload));
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var algorithm = (string)headerData["alg"];
            var computedJwtSignature = Encoding.UTF8.GetString(HashAlgorithms[GetHashAlgorithm(algorithm)](keyBytes, bytesToSign));
            // var decodedCrypto = Convert.ToBase64String(crypto);
            // var decodedSignature = Convert.ToBase64String(signature);
            
            if (jwtSignature != computedJwtSignature)
            {
                throw new ApplicationException(string.Format("Invalid signature. Expected {0} got {1}", decodedCrypto, decodedSignature));
            }
        }
    
        return payloadData.ToString();
    }
