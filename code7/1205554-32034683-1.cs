    static string GenerateSignature(string endpoint, Dictionary<string,string> parameters, string secret)
    {
        // Build the message to be authenticated
        StringBuilder message = new StringBuilder(endpoint);
        foreach (var param in parameters.OrderBy(p => p.Key))
        {
            message.AppendFormat("|{0}={1}", param.Key, param.Value);
        }
        // Create a HMAC-SHA256 digest of the message using the secret key
        HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        byte[] digest = hmac.ComputeHash(Encoding.UTF8.GetBytes(message.ToString()));
        // Return the digest as a hexstring to be used as a signature for the request
        return ByteArrayToString(digest);
    }
    static string ByteArrayToString(byte[] array)
    {
        // Convert the bytes in the array to a lower-case hexstring
        return array.Aggregate(new StringBuilder(), (sb, b) => sb.Append(b.ToString("x2"))).ToString();
    }
    static void Main(string[] args)
    {
        string secret = "6dc1787668c64c939929c17683d7cb74";
        string endpoint;
        Dictionary<string, string> parameters;
        string signature;
        // Example 1
        endpoint = "/users/self";
        parameters = new Dictionary<string, string>
        {
            { "access_token", "fb2e77d.47a0479900504cb3ab4a1f626d174d2d" },
        };
        signature = GenerateSignature(endpoint, parameters, secret);
        Console.WriteLine("sig={0}", signature);
        // Example 2
        endpoint = "/media/657988443280050001_25025320";
        parameters = new Dictionary<string, string>
        {
            { "access_token", "fb2e77d.47a0479900504cb3ab4a1f626d174d2d" },
            { "count", "10" },
        };
        signature = GenerateSignature(endpoint, parameters, secret);
        Console.WriteLine("sig={0}", signature);
        Console.ReadKey(true);
    }
