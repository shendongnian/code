	public async Task<RES> PostAsync<RES>(string url, string content) where RES : new()
	{
		using (var client = new HttpClient())
		{
			HttpResponseMessage message = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
			var readAsStringAsync = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
			return await readAsStringAsync.FromJsonAsync<RES>(mySerializerSettings).ConfigureAwait(false);
		}
	}
