	public static string GetEncodedSignature(string toSign, string hashKey)
	{
		byte[] bytes;
		byte[] unicodeKey = Convert.FromBase64String(hashKey);
		var utf8encodedString = Encoding.UTF8.GetBytes(toSign);
		using (var hmac = new HMACSHA256(unicodeKey))
		{
			bytes = hmac.ComputeHash(utf8encodedString);
		}
		var signature = Convert.ToBase64String(bytes);
		return signature;
	}
