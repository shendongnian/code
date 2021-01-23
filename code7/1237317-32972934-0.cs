    using System.Security.Cryptography;
    using System.IO;
    Encryption
    public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] encryptedBytes = null;
        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;
                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Mode = CipherMode.CBC;
                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }
                encryptedBytes = ms.ToArray();
            }
        }
        return encryptedBytes;
    }
    Decryption
    public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] decryptedBytes = null;
        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;
                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Mode = CipherMode.CBC;
                using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }
                decryptedBytes = ms.ToArray();
            }
        }
        return decryptedBytes;
    }
    Example of Encrypting File
    Encrypt File
    public void EncryptFile()
    {
        string file = "C:\\SampleFile.DLL";
        string password = "abcd1234";
        byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        // Hash the password with SHA256
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
        string fileEncrypted = "C:\\SampleFileEncrypted.DLL";
        File.WriteAllBytes(fileEncrypted, bytesEncrypted);
    }
    Decrypt File
    public void DecryptFile()
    {
        string fileEncrypted = "C:\\SampleFileEncrypted.DLL";
        string password = "abcd1234";
        byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
        byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
        string file = "C:\\SampleFile.DLL";
        File.WriteAllBytes(file, bytesDecrypted);
    }
    Getting Randomized Encryption Result with Salt
    If we encrypt the same context (i.e. string of "Hello World") for 10 times, the encrypted results will be the same. What if we want the results different from each time it is encrypted?
    What I do is appending a random salt bytes in front of the original bytes before encryption, and remove it after decryption.
    Example of Appending Randomized Salt Before Encrypting a String
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
    Example of Removing the Salt after Decryption
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
    Code for getting random bytes
    public byte[] GetRandomBytes()
    {
        int _saltSize = 4;
        byte[] ba = new byte[_saltSize];
        RNGCryptoServiceProvider.Create().GetBytes(ba);
        return ba;
    }
