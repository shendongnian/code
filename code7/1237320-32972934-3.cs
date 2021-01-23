    public string Encrypt(string text, string pwd)
    {
        byte[] originalBytes = Encoding.UTF8.GetBytes(text);
        byte[] encryptedBytes = null;
        byte[] passwordBytes = Encoding.UTF8.GetBytes(pwd);
        // Hash the password with SHA256
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        // Generating salt bytes
        byte[] saltBytes = GetRandomBytes();
        // Appending salt bytes to original bytes
        byte[] bytesToBeEncrypted = new byte[saltBytes.Length + originalBytes.Length];
        for (int i = 0; i < saltBytes.Length; i++)
        {
            bytesToBeEncrypted[i] = saltBytes[i];
        }
        for (int i = 0; i < originalBytes.Length; i++)
        {
            bytesToBeEncrypted[i + saltBytes.Length] = originalBytes[i];
        }
        encryptedBytes = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
        return Convert.ToBase64String(encryptedBytes);
    }
