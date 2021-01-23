    public async Task<IActionResult> SignIn(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return View("MissingCredentials");
        }
        var request = new HttpRequestMessage(HttpMethod.Post, "http://server.com/connect/token");
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = "your client_id",
            ["client_secret"] = "your client_secret",
            ["grant_type"] = "password",
            ["username"] = "username",
            ["password"] = "password"
        });
    
        var response = await client.SendAsync(request, notification.Request.CallCancelled);
        response.EnsureSuccessStatusCode();
    
        var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
        var token = payload.Value<string>("access_token");
        if (string.IsNullOrEmpty(token))
        {
            return View("InvalidCredentials");
        }
        var identity = new ClaimsIdentity("Cookies");
        identity.AddClaim(new Claim("access_token", token));
        return SignIn(new ClaimsPrincipal(identity), "Cookies");
    }
