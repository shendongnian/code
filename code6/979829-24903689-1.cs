    public byte[] Encrypt(byte[] data)
    {
    	if (CanPerformCryptography(data))
    	{
    		using (var encryptor = _algorithm.CreateEncryptor(_key, _iv))
    		{
    			return PerformCryptography(encryptor, data);
    		}
    	}
    	return data;
    }
    
    public byte[] Decrypt(byte[] data)
    {
    	if (CanPerformCryptography(data))
    	{
    		using (var decryptor = _algorithm.CreateDecryptor(_key, _iv))
    		{
    			return PerformCryptography(decryptor, data);
    		}
    	}
    	return data;
    }
