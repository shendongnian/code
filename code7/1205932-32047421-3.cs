		public async Task SendDataAsync(Email email)
		{
			using (var client = new HttpClient())
			{
				var response = await client.PostAsync(email);
			}
		}
