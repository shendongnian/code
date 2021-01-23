    public static async Task RefreshDataAsync ()
		{
			var uri = new Uri ("http://www.pizzaboy.de/app/pizzaboy.json");
			HttpClient myClient = new HttpClient();
			var response = await myClient.GetAsync (uri);
			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				var Items = JsonConvert.DeserializeObject <List<RootObject>> (content);
				Console.WriteLine ("");
			}
		}
