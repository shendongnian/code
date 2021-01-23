    private AesCryptoServiceProvider GetProvider(string passphrase, byte[] salt)
    {
        AesCryptoServiceProvider result = new AesCryptoServiceProvider();
        result.BlockSize = 128;
        result.KeySize = 128;
        result.Mode = CipherMode.CBC;
        result.Padding = PaddingMode.PKCS7;
    
        var derived = this.Derive48(passphrase, salt);
                
        result.Key = derived.Take(32).ToArray();
        result.IV = derived.Skip(32).Take(16).ToArray();
    
        return result;
    }
