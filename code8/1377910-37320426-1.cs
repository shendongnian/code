    public async Task<ActionResult> Login(LoginViewModel loginViewModel)
    {
		HttpClient client = new HttpClient();
		client.BaseAddress = new Uri("http://localhost:63465");
		var response = await client.PostAsJsonAsync("api/login", loginViewModel); //Since it's a post it will automatically trigger corresponding post method on your webAPI
		if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return RedirectToActionPermanent("Index", "Project");
        }
        return View(loginViewModel);
    }
