    public static string Encrypt(this string plainText)
    {
        RijndaelManaged aes = new RijndaelManaged();
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.CBC;
        aes.Key = Encoding.Default.GetBytes(key);
        aes.GenerateIV();
        ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
        byte[] buffer = Encoding.ASCII.GetBytes(plainText);
        String encryptedText = Convert.ToBase64String(Encoding.Default.GetBytes(Encoding.Default.GetString(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length))));
        String mac = "";
        using (var hmacsha256 = new HMACSHA256(Encoding.Default.GetBytes(key)))
        {
            hmacsha256.ComputeHash(Encoding.Default.GetBytes(Convert.ToBase64String(aes.IV) + encryptedText));
            mac = ByteArrToString(hmacsha256.Hash);
        }
        var keyValues = new Dictionary<string, object>
        {
            { "iv", Convert.ToBase64String(aes.IV) },
            { "value", encryptedText },
            { "mac", mac },
        };
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //return serializer.Serialize(keyValues);
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(serializer.Serialize(keyValues)));
    }
    public static string Decrypt(this string cipherText)
    {
        RijndaelManaged aes = new RijndaelManaged();
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.CBC;
        aes.Key = Encoding.Default.GetBytes(key);
        dynamic payload = GetJsonPayload(cipherText);
        //return Encoding.Default.GetString(Convert.FromBase64String(cipherText));
        //cipherText = Convert.ToBase64String(Encoding.Default.GetBytes(payload["value"]));
        aes.IV = Convert.FromBase64String(payload["iv"]);
            
        ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
        byte[] buffer = Convert.FromBase64String(payload["value"]);
            
        return (Encoding.Default.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length))).ToString();
    }
