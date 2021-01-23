        public void Crypt(byte[] data, string filepath)
        {
            // Define password and salt
            byte[] pwd = GetBytes("PASSWORD");
            byte[] salt = GetBytes("SALT");
            // Generate PasswordDeriveBytes from the password and salt.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(pwd, salt);
            // Generate key from PasswordDeriveBytes
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = pdb.CryptDeriveKey("TripleDES", "SHA1", 192, tdes.IV);
            // Encrypt/Decrypt
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ tdes.Key[i % tdes.Key.Length]);
            }
            // Save File
            File.WriteAllBytes(filepath, data);   
        }
