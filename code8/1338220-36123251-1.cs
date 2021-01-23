    public void DecryptFileExample(string fileName, string password)
    {
        byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);
            RijndaelManaged rm = new RijndaelManaged();
            CryptoStream strm = new CryptoStream(fs, rm.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)), CryptoStreamMode.Read);
			using (StreamReader srDecrypt = new StreamReader(strm))
			{
				var str = srDecrypt.ReadToEnd();
				Console.WriteLine(str);
			}
        }
    }
