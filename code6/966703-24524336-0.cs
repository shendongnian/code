    public static string DecryptDLCData(string data, string _key, Encoding encoding = null)
		{
			if (encoding == null)
				encoding = Encoding.Default;
			data = data.DecodeBase64(encoding);
			RijndaelManaged rijndaelCipher = new RijndaelManaged();
			rijndaelCipher.Mode = CipherMode.CBC;
			rijndaelCipher.Padding = PaddingMode.Zeros;
			rijndaelCipher.KeySize = 256;
			rijndaelCipher.BlockSize = 128;
			byte[] pwdBytes = Encoding.Default.GetBytes(_key);
			byte[] keyBytes = new byte[16];
			int len = pwdBytes.Length;
			if (len > keyBytes.Length) len = keyBytes.Length;
			Array.Copy(pwdBytes, keyBytes, len);
			rijndaelCipher.Key = keyBytes;
			rijndaelCipher.IV = keyBytes;
			var transform = rijndaelCipher.CreateDecryptor();
			byte[] plainText = Encoding.Default.GetBytes(data);
			byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);
			return Encoding.UTF8.GetString(cipherBytes);
		}
