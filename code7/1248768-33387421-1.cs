	class Program
	{
		public static byte[] GetKey(string siteSecret)
		{
			byte[] key = Encoding.UTF8.GetBytes(siteSecret);
			return SHA1.Create().ComputeHash(key).Take(16).ToArray();
		}
		public static string EncryptAes(string input, string siteSecret)
		{
			var key = GetKey(siteSecret);
			using (var aes = AesManaged.Create())
			{
				if (aes == null) return null;
				aes.Mode = CipherMode.ECB;
				aes.Padding = PaddingMode.PKCS7;
				aes.Key = key;
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);
				var enc = aes.CreateEncryptor(key, new byte[16]);
				return UrlSafeBase64(enc.TransformFinalBlock(inputBytes,0,input.Length));
			}
		}
		// http://stackoverflow.com/a/26354677/162671
		public static string UrlSafeBase64(byte[] bytes)
		{
			return Convert.ToBase64String(bytes).TrimEnd('=')
				.Replace('+', '-')
				.Replace('/', '_');
		}
		static void Main(string[] args)
		{
			string siteSecret = "12345678";
			string jsonToken = "{'session_id':'abf52ca5-9d87-4061-b109-334abb7e637a','ts_ms':1445705791480}";
			Console.WriteLine(" json token: " + jsonToken);
			Console.WriteLine(" siteSecret: " + siteSecret);
			Console.WriteLine(EncryptAes(jsonToken, siteSecret));
			Console.ReadLine();
		}
	}
