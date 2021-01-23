	static string Base64UrlEncode (MimeMessage message)
	{
		using (var stream = new MemoryStream ()) {
			message.WriteTo (stream);
			return Convert.ToBase64String (stream.GetBuffer (), 0, (int) stream.Length)
				.Replace ('+', '-')
				.Replace ('/', '_')
				.Replace ("=", "");
		}
	}
