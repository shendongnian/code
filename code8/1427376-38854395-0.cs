	public class MyEmailSenderOne : IEmailSender
	{
		public static readonly string tokenUrl = ConfigurationManager.AppSettings["tokenUrl"];
		public static readonly string tokenKey = ConfigurationManager.AppSettings["tokenKey"];
	
		public async Task<bool> Send(Email email)
		{
			var http = new HttpClient();
			http.DefaultRequestHeaders.Add("subscription-key", tokenKey);
	
			try
			{
				await http.PostAsync(tokenUrl + "email", new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json"));
			}
			catch (Exception e)
			{
				return false;
			}
	
			return true;
		}
	}
	
