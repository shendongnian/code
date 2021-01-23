        public static byte[] EncryptBytes(byte[] inputBytes, string passPhrase, string saltValue)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            RijndaelCipher.Mode = CipherMode.CBC;
            RijndaelCipher.Padding = PaddingMode.PKCS7;
            byte[] salt = Encoding.UTF32.GetBytes(saltValue);
            //byte[] salt = Encoding.ASCII.GetBytes(saltValue);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt, "SHA1", 2);
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(password.GetBytes(32), password.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Flush();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return CipherBytes;
        }
        public static byte[] DecryptBytes(byte[] encryptedBytes, string passPhrase, string saltValue)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            RijndaelCipher.Mode = CipherMode.CBC;
            RijndaelCipher.Padding = PaddingMode.PKCS7;
            byte[] salt = Encoding.UTF32.GetBytes(saltValue);
            //byte[] salt = Encoding.ASCII.GetBytes(saltValue);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt, "SHA1", 2);
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(password.GetBytes(32), password.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(encryptedBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            byte[] plainBytes = new byte[encryptedBytes.Length];
            int DecryptedCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);
            memoryStream.Flush();
            cryptoStream.Flush();
            memoryStream.Close();
            cryptoStream.Close();
            return plainBytes.Take(DecryptedCount).ToArray();
        }
        public static byte[] GetData(string FileName)
        {
            return File.ReadAllBytes(FileName);
        }
        protected bool SaveData(string FileName, byte[] Data)
        {
            try
            {
                File.WriteAllBytes(FileName, Data);
                return true;
            }
            catch
            {
                return false;
            }
        }
