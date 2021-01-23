		public static byte[] EncryptData(string keyString, byte[] dataToEncrypt)
		{
			if (keyString.IsNullOrEmptyTrimmed())
				throw new ArgumentNullException("keyString", "You must provide a key string for salting.");
			if (dataToEncrypt == null)
				return null;
			UTF8Encoding utf8 = new UTF8Encoding();
			byte[] encryptedData;
			MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
			byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(keyString));
			TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();
			tdesAlgorithm.Key = tdesKey;
			tdesAlgorithm.Mode = CipherMode.ECB;
			tdesAlgorithm.Padding = PaddingMode.PKCS7;
			try
			{
				ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor();
				encryptedData = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
			}
			finally
			{
				tdesAlgorithm.Clear();
				hashProvider.Clear();
			}
			return encryptedData;
		}
        public static byte[] DecryptData(string keyString, byte[] encyptedData)
		{
			if (encyptedData == null)
				return null;
			byte[] decryptedData;
			UTF8Encoding utf8 = new UTF8Encoding();
			MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
			byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(keyString));
			TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();
			tdesAlgorithm.Key = tdesKey;
			tdesAlgorithm.Mode = CipherMode.ECB;
			tdesAlgorithm.Padding = PaddingMode.PKCS7;
			try
			{
				ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
				decryptedData = decryptor.TransformFinalBlock(encyptedData, 0, encyptedData.Length);
			}
			finally
			{
				tdesAlgorithm.Clear();
				hashProvider.Clear();
			}
			return decryptedData;
		}
