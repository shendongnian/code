		public bool ValidateShopifyHmac(string hmacHeader, string localData, string apiKey) {
			var ascii = new ASCIIEncoding();
			var keyBytes = ascii.GetBytes(apiKey);
			var cryptographer = new System.Security.Cryptography.HMACSHA256(keyBytes);
			var messageBytes = ascii.GetBytes(localData);
			var hashedMessage = cryptographer.ComputeHash(messageBytes);
			var digest = BitConverter.ToString(hashedMessage).Replace("-", "");
			return digest == hmacHeader.ToUpper();
		}
