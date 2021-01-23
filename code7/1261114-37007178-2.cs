    private string encrypt(string plainText)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            aes.Key = Convert.FromBase64String(key);
            aes.GenerateIV();
            ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] buffer = Encoding.ASCII.GetBytes(phpSerialize(plainText));
            
            String encryptedText = Convert.ToBase64String(Encoding.Default.GetBytes(Encoding.Default.GetString(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length))));
            String mac = "";
            using (var hmacsha256 = new HMACSHA256(Convert.FromBase64String(key)))
            {
                hmacsha256.ComputeHash(Encoding.Default.GetBytes(Convert.ToBase64String(aes.IV) + encryptedText));
                mac = ByteToString(hmacsha256.Hash);
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
