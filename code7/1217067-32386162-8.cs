	public static string GetEncodedSignature(string stringToSign)
	{
		byte[] bytes;
		byte[] unicodeKey = Convert.FromBase64String(SHARED_KEY);
		var utf8encodedString = Encoding.UTF8.GetBytes(stringToSign);
		using (var hmac = new HMACSHA256(unicodeKey))
		{
			bytes = hmac.ComputeHash(utf8encodedString);
		}
		var signature = Convert.ToBase64String(bytes);
		return signature;
	}
