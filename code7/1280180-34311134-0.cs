	public string DecryptRijndael(byte[] cipherText, string password, byte[] iv)
	{
		var key = new byte[32];
		Encoding.UTF8.GetBytes(password).CopyTo(key, 0);
		var cipher = new RijndaelManaged();
		cipher.Mode = CipherMode.CBC;
		cipher.Padding = PaddingMode.None;
		cipher.KeySize = 256;
		cipher.BlockSize = 256;
		cipher.Key = key;
		cipher.IV = iv;
		byte[] plain;
		using (var decryptor = cipher.CreateDecryptor())
		{
			using (MemoryStream ms = new MemoryStream())
			{
				using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
				{
					cs.Write(cipherText, 0, cipherText.Length);
					cs.FlushFinalBlock();
					plain = ms.ToArray();
				}
			}
		}
		return Encoding.UTF8.GetString(plain);
	}
