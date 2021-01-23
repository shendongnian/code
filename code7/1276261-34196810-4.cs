    public static string Protect(string stringToEncrypt, string optionalEntropy, DataProtectionScope scope)
    {
        return Convert.ToBase64String(
            ProtectedData.Protect(
                Encoding.UTF8.GetBytes(stringToEncrypt)
                , optionalEntropy != null ? Encoding.UTF8.GetBytes(optionalEntropy) : null
                , scope));
    }
