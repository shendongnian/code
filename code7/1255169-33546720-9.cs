    public string Hash(string password)
    {
        var bytes = new UTF8Encoding().GetBytes(password);
        var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
        return Convert.ToBase64String(hashBytes);
    }
