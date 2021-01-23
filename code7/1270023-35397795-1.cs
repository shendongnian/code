		public bool ValidateShopifyHmac(string hmacHeader, string localData, string apiSecret) {
			var ascii = new ASCIIEncoding();
			var secretBytes = ascii.GetBytes(apiSecret);
			var cryptographer = new System.Security.Cryptography.HMACSHA256(secretBytes);
			var messageBytes = ascii.GetBytes(localData);
			var hashedMessage = cryptographer.ComputeHash(messageBytes);
			var digest = BitConverter.ToString(hashedMessage).Replace("-", "");
			return digest == hmacHeader.ToUpper();
		}
