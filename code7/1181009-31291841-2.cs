	public async Task<ActionResult> Check()
	{
		using (var client = new HttpClient())
		{
			var search = new UserSearch() { Email = "a@b.c" };
			var response = await client.PostAsJsonAsync("http://localhost:59305/api/User/CheckUserExist", search);
			if (response.IsSuccessStatusCode)
			{
				bool exists = await response.Content.ReadAsAsync<bool>();
				// Handle what to do with exists
				return RedirectToAction("Index");
			}
			else
			{
				// Handle unsuccessful call
				throw new Exception("Application error");
			}
		}
	}
	
