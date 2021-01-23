    static GmailService Service;
		public static void CriaService(string emailaConectar)
		{
			var certificate = new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ClientCredentials.CertificatePath), ClientCredentials.ClientSecret, X509KeyStorageFlags.Exportable);
			var credential = new ServiceAccountCredential(
				new ServiceAccountCredential.Initializer(ClientCredentials.ServiceAccountEmail)
				{
					Scopes = new[] { GmailService.Scope.GmailCompose },
					User = emailaConectar
				}.FromCertificate(certificate)) { };
			Service = new GmailService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ClientCredentials.ApplicationName,
			});
		}
		private static string Base64UrlEncode(string input)
		{
			var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			// Special "url-safe" base64 encode.
			return Convert.ToBase64String(inputBytes)
			  .Replace('+', '-')
			  .Replace('/', '_')
			  .Replace("=", "");
		}
