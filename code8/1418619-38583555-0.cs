    private static string HashSignature(string password, string message)
    {
    var key = Encoding.UTF8.GetBytes(password.ToUpper());
    string hashData;
    using (var hmac = new HMACSHA256(key))
    {
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        hashData= Convert.ToBase64String(hash);
    }
    return hashData;
    }
