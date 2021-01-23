    internal const string Inputkey = "560A18CD-6346-4CF0-A2E8-671F9B6B9EA9";
        ///<summary>
        /// Arvind - 23/11/2017.
        ///
        /// Encrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"+kdkdkdjd8656589$**hh$^JHJBKLJJH#$$$__+0-f5546%$$^5434+"; // Secret Key
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                Rijndael RMCrypto = NewRijndaelManaged(password);
                var encryptor = RMCrypto.CreateEncryptor(RMCrypto.Key, RMCrypto.IV);
                CryptoStream cs = new CryptoStream(fsCrypt,
                    encryptor,
                    CryptoStreamMode.Write);
                FileStream fsIn = new FileStream(inputFile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);
                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Encryption failed!" + ex.Message);
            }
        }
		
		
		/// <summary>
        /// Create a new RijndaelManaged class and initialize it
        /// </summary>
        /// <param name="salt" />The pasword salt
        /// <returns></returns>
		private static RijndaelManaged NewRijndaelManaged(string salt)
        {
            if (salt == null) throw new ArgumentNullException("salt");
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(Inputkey, saltBytes);
            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
            return aesAlg;
        }
		
		**File decryption**
    ///<summary>
        /// Arvind - 23/11/2017.
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void DecryptDatabaseFile(string inputFile, string outputFile)
        {
            try
            {
                string password = System.Configuration.ConfigurationManager.AppSettings["encryptionKey"];
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
                var aesAlg = NewRijndaelManaged(password);
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                CryptoStream cs = new CryptoStream(fsCrypt,
                   decryptor,
                    CryptoStreamMode.Read);
                FileStream fsOut = new FileStream(outputFile, FileMode.Create);
                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);
                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("decryption Fail!!" + ex.Message);
            }
        }
