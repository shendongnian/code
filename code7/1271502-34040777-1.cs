    private readonly System.Security.Cryptography.HashAlgorithm hash = System.Security.Cryptography.SHA1.Create();
    public static string CalculateSignature(IEnumerable<object> values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
        {
            string valueToHash = value == null ? ">>null<<" : Convert.ToString(value, CultureInfo.InvariantCulture);
            sb.Append(valueToHash).Append(char.ConvertFromUtf32(0));
        }
        var signature = sb.ToString();
        var bytesToHash = Encoding.UTF8.GetBytes(signature);
        var hashedBytes = hash.ComputeHash(bytesToHash);
        signature = Encoding.UTF8.GetString(hashedBytes);
        return signature;
    }
