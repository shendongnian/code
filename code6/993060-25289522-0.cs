        private string Crypt(string s_Data, bool b_Encrypt)
        {
            string s_Password = "... your password ...";
            byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };
            PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(s_Password, u8_Salt);
            Rijndael i_Alg = Rijndael.Create();
            i_Alg.Key = i_Pass.GetBytes(32);
            i_Alg.IV = i_Pass.GetBytes(16);
            ICryptoTransform i_Trans = (b_Encrypt) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();
            MemoryStream i_Mem = new MemoryStream();
            CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write);
            byte[] u8_Data;
            if (b_Encrypt) { u8_Data = Encoding.Unicode.GetBytes(s_Data); }
            else
            {
                try { u8_Data = Convert.FromBase64String(s_Data); }
                catch { return null; }
            }
            try
            {
                i_Crypt.Write(u8_Data, 0, u8_Data.Length);
                i_Crypt.Close();
            }
            catch { return string.Empty; }
            if (b_Encrypt) return Convert.ToBase64String(i_Mem.ToArray());
            else return Encoding.Unicode.GetString(i_Mem.ToArray());
        }
