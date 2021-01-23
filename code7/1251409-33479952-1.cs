    public static string GetTransactionEncryptionKey(string merchantOrder, string encryptKey)
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.IV = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    tdes.Key = Convert.FromBase64String(encryptKey);
                    tdes.Padding = PaddingMode.Zeros;
                    tdes.Mode = CipherMode.CBC;
    
                    var toEncrypt = ASCIIEncoding.ASCII.GetBytes(merchantOrder);
                    var result = tdes.CreateEncryptor().TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
    
                    return Convert.ToBase64String(result);
                }
            }
