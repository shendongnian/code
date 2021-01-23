    public static string GetHash(string input)
            {
                HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();
    
                byte[] byteValue = System.Text.Encoding.Unicode.GetBytes(input);
                byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
    
                return Convert.ToBase64String(byteHash);
            }
