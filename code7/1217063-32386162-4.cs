	public static string GetEncodedSignature(string stringToSign)
	{
		var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SHARED_KEY));
		var bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
		var signature = Convert.ToBase64String(bytes);
		return signature;
	}
