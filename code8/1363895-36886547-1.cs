    public string Decrypt(string toDecrypt, string key, bool useHashing)
    {
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        byte[] keyArray;
        byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
        string keyArrayStr = "";
        if (useHashing)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(key));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            keyArrayStr = sb.ToString().Substring(0, tdes.Key.Length);
            keyArray = UTF8Encoding.UTF8.GetBytes(keyArrayStr);
        }
        else
        {
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
        }
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.Zeros;
        ICryptoTransform cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        var strValue = UTF8Encoding.UTF8.GetString(resultArray);
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
