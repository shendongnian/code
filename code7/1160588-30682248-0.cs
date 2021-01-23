    public string AES_Encrypt(string input, string pass)
    {
    SymmetricKeyAlgorithmProvider SAP = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
    CryptographicKey AES;
    HashAlgorithmProvider HAP = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
    CryptographicHash Hash_AES = HAP.CreateHash();
            
    string encrypted = "";
    try
    {
        byte[] hash = new byte[32];
        Hash_AES.Append(CryptographicBuffer.CreateFromByteArray(System.Text.Encoding.UTF8.GetBytes(pass)));
        byte[] temp;
        CryptographicBuffer.CopyToByteArray(Hash_AES.GetValueAndReset(), out temp);
        Array.Copy(temp, 0, hash, 0, 16);
        Array.Copy(temp, 0, hash, 15, 16);
        AES = SAP.CreateSymmetricKey(CryptographicBuffer.CreateFromByteArray(hash));   
                
        IBuffer Buffer = CryptographicBuffer.CreateFromByteArray(System.Text.Encoding.UTF8.GetBytes(input));
        encrypted = CryptographicBuffer.EncodeToBase64String(CryptographicEngine.Encrypt(AES, Buffer, null));
        return encrypted;
    }
    catch (Exception ex)
    {
        return null;
    }
    }
        
    public string AES_Decrypt(string input, string pass)
    {
    SymmetricKeyAlgorithmProvider SAP = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
    CryptographicKey AES;
    HashAlgorithmProvider HAP = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
    CryptographicHash Hash_AES = HAP.CreateHash();
    string decrypted = "";
    try
    {
        byte[] hash = new byte[32];
        Hash_AES.Append(CryptographicBuffer.CreateFromByteArray(System.Text.Encoding.UTF8.GetBytes(pass)));
        byte[] temp;
        CryptographicBuffer.CopyToByteArray(Hash_AES.GetValueAndReset(), out temp);
        Array.Copy(temp, 0, hash, 0, 16);
        Array.Copy(temp, 0, hash, 15, 16);
        AES = SAP.CreateSymmetricKey(CryptographicBuffer.CreateFromByteArray(hash));   
                
        IBuffer Buffer = CryptographicBuffer.DecodeFromBase64String(input);
        byte[] Decrypted;
        CryptographicBuffer.CopyToByteArray(CryptographicEngine.Decrypt(AES, Buffer, null), out Decrypted);
        decrypted = System.Text.Encoding.UTF8.GetString(Decrypted, 0, Decrypted.Length);
        return decrypted;
    }
    catch (Exception ex)
    {
        return null;
    }
    }
