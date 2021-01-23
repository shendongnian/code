    public static string GeneratePasswordHash(string password, string salt)
    {
       Byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
       Byte[] hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(passwordBytes);
       return BitConverter.ToString(hashedBytes).Replace("-", String.Empty);
    }
