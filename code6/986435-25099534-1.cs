    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    des.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
    des.IV = IV;
    byt = Convert.FromBase64String(value);
    byte[] decrypted  = des.CreateDecryptor().TransformFinalBlock(byt, 0, byt.Length)
    return Encoding.ASCII.GetString(decrypted);
