    using System.Security.Cryptography;
    ...
    ...
    ...
    private const string _alg = "HmacSHA256";
    private const string _salt = "rz8LuOtFBXphj9WQfvFh"; // Generated at https://www.random.org/strings
    
    public static string GenerateToken(string username, string password)
    {
        string hash = string.Join(":", new string[] { username, password });
    
        using (HMAC hmac = HMACSHA256.Create(_alg))
        {
            hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
            hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));
    
            hash = Convert.ToBase64String(hmac.Hash);
        }
    
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(hash));
    }
    
    public static string GetHashedPassword(string password)
    {
        string key = string.Join(":", new string[] { password, _salt });
    
        using (HMAC hmac = HMACSHA256.Create(_alg))
        {
            // Hash the key.
            hmac.Key = Encoding.UTF8.GetBytes(_salt);
            hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
    
            return Convert.ToBase64String(hmac.Hash);
        }
    }
