		var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "[USERNAME]", "[PASSWORD]")));
		using (var httpClient = new HttpClient())
		{
			httpClient.DefaultRequestHeaders.Add("User-Agent", "MyApp [EMAIL ADDRESS]");
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
			var response = await httpClient.PostAsJsonAsync(
				"https://basecamp.com/[USER ID]/api/v1/projects.json",
				new {
					name = "My Project",
					description = "My Project Description"
				});
			
			var responseContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine(responseContent);
		}
