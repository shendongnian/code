    public static string Encrypt(string PlainText, string Password,
                   string Salt = "Kosher", string HashAlgorithm = "SHA1",
                   int PasswordIterations = 2, string InitialVector = "OFRna73m*aze01xY",
                   int KeySize = 256)
               {
                   if (string.IsNullOrEmpty(PlainText))
                       return "";
                   byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                   byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
                   byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
                   PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
                   byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
                   RijndaelManaged SymmetricKey = new RijndaelManaged();
                   SymmetricKey.Mode = CipherMode.CBC;
                   byte[] CipherTextBytes = null;
                   using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
                   {
                       using (MemoryStream MemStream = new MemoryStream())
                       {
                           using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                           {
                               CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                               CryptoStream.FlushFinalBlock();
                               CipherTextBytes = MemStream.ToArray();
                               MemStream.Close();
                               CryptoStream.Close();
                           }
                       }
                   }
                   SymmetricKey.Clear();
                   return Convert.ToBase64String(CipherTextBytes);
               }
