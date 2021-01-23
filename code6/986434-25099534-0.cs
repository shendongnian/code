    byt = Convert.FromBase64String(value);
    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    des.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
    des.IV = IV;
    return Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(byt, 0, byt.Length));
