	public static string GetEncodedSignature(string stringToSign)
	{
		string signature = string.Empty;
		byte[] unicodeKey = Convert.FromBase64String(SHARED_KEY);
		using(var hmac = new HMACSHA256(unicodeKey))
		{
			var utf8encodedString = Encoding.UTF8.GetBytes(stringToSign);
			var bytes = hmac.ComputeHash(utf8encodedString);
			signature = Convert.ToBase64String(bytes);
		}
		return signature;
	}
