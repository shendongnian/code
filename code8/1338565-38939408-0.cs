    public async Task<string> GetJWTToken(string user) {
        //...other code removed for brevity
        //constructing part 3: HS512(part1 + "." + part2, key)
        var tobeHashed = string.Join(".", partOne, partTwo);
        var sha = new HMACSHA512(Encoding.UTF8.GetBytes(ConfigurationHelper.AppSettings("JWTOfferKey")));
        var hashedByteArray = sha.ComputeHash(Encoding.UTF8.GetBytes(tobeHashed));
        //You need to base64UrlEncode the signature hash value
        var partThree = Base64UrlEncode(hashedByteArray);
 
        //Now construct the token
        var tokenString = string.Join(".", tobeHashed, partThree);
        return tokenString;
    }
    // from JWT spec
    private static string Base64UrlEncode(byte[] input) {
        var output = Convert.ToBase64String(input);
        output = output.Split('=')[0]; // Remove any trailing '='s
        output = output.Replace('+', '-'); // 62nd char of encoding
        output = output.Replace('/', '_'); // 63rd char of encoding
        return output;
    }
