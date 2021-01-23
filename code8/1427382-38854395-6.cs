	public class MyEmailSenderOne : IEmailSender
	{
		private FormSettings _settings;
	
		public MyEmailSenderOne(IOptions<FormSettings> settings)
		{
			_settings = settings.Value;
		}
	
		public async Task<bool> Send(Email email)
		{
			var http = new HttpClient();
			http.DefaultRequestHeaders.Add("subscription-key", _settings.tokenApiKey);
	
			try
			{
				await http.PostAsync(_settings.tokenApiUrl + "email", new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json"));
			}
			catch (Exception e)
			{
				return false;
			}
	
			return true;
		}
	}
