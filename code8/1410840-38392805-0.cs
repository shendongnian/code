        /// <summary>
		/// The HTTP request will contain an X-Hub-Signature header which contains the SHA1 signature of the request payload,
		/// using the app secret as the key, and prefixed with sha1=.
		/// Your callback endpoint can verify this signature to validate the integrity and origin of the payload
		/// </summary>
		/// <param name="appSecret">facebook app secret</param>
		/// <param name="payload">body of webhook post request</param>
		/// <returns>calculated signature</returns>
        public static string CalculateSignature(string appSecret, string payload)
		{
			/*
			 Please note that the calculation is made on the escaped unicode version of the payload, with lower case hex digits.
			 If you just calculate against the decoded bytes, you will end up with a different signature.
			 For example, the string äöå should be escaped to \u00e4\u00f6\u00e5.
			 */
			payload = EncodeNonAsciiCharacters(payload);
			byte[] secretKey = Encoding.UTF8.GetBytes(appSecret);
			HMACSHA1 hmac = new HMACSHA1(secretKey);
			hmac.Initialize();
			byte[] bytes = Encoding.UTF8.GetBytes(payload);
			byte[] rawHmac = hmac.ComputeHash(bytes);
			return ByteArrayToString(rawHmac).ToLower();
		}
		private static string EncodeNonAsciiCharacters(string value)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in value)
			{
				if (c > 127)
				{
					string encodedValue = "\\u" + ((int)c).ToString("x4");
					sb.Append(encodedValue);
				}
				else
				{
					sb.Append(c);
				}
			}
			return sb.ToString();
		}
		private static string ByteArrayToString(byte[] ba)
		{
			string hex = BitConverter.ToString(ba);
			return hex.Replace("-", "");
		}
