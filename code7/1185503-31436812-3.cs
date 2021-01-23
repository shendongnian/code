    // using System.Security.Cryptography;
    public static string ComputeHashSha256(byte[] toBeHashed)
    {
        using (var sha256 = SHA256.Create())
        {
            return Encoding.UTF8.GetString(sha256.ComputeHash(toBeHashed));
        }
    }
