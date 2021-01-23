    string clearText = "test";
    string key = "012345678901234567890123";
    string encryptedText = "";
    
    byte[] keyBytes = new byte[24];
    
    MD5 md5 = new MD5CryptoServiceProvider();
    TripleDES des = new TripleDESCryptoServiceProvider();
    des.KeySize = 128;
    des.Mode = CipherMode.CBC;
    des.Padding = PaddingMode.PKCS7;
    
    byte[] md5Bytes = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
    for (int i = 0; i < md5Bytes.Length; i++)
    {
    	keyBytes[i] = md5Bytes[i];
    }
    
    byte[] ivBytes = new byte[8];
    
    
    des.Key = md5Bytes;
    
    des.IV = ivBytes;
    
    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
    
    ICryptoTransform ct = des.CreateEncryptor();
    using (MemoryStream ms = new MemoryStream())
    {
    	using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
    	{
    		cs.Write(clearBytes, 0, clearBytes.Length);
    		cs.Close();
    	}
    	encryptedText = Convert.ToBase64String(ms.ToArray());
    }
