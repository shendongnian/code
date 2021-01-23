    public string Decrypt(string decryptedText, string pwd)
    {
        byte[] bytesToBeDecrypted = Convert.FromBase64String(decryptedText);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(pwd);
        // Hash the password with SHA256
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        byte[] decryptedBytes = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
        // Getting the size of salt
        int _saltSize = 4;
        // Removing salt bytes, retrieving original bytes
        byte[] originalBytes = new byte[decryptedBytes.Length - _saltSize];
        for (int i = _saltSize; i < decryptedBytes.Length; i++)
        {
            originalBytes[i - _saltSize] = decryptedBytes[i];
        }
        return Encoding.UTF8.GetString(originalBytes);
    }
