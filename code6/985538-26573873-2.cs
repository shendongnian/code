    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        /*This will depend totally on how you will get access to the identity provider and get your token, this is just a sample of how it would be done*/
        /*Get Access Token Start*/
        HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://youridentityproviderbaseurl");
        var postData = new List<KeyValuePair<string, string>>();
        postData.Add(new KeyValuePair<string, string>("UserName", model.Email));
        postData.Add(new KeyValuePair<string, string>("Password", model.Password));
        HttpContent content = new FormUrlEncodedContent(postData);
          
        HttpResponseMessage response = await httpClient.PostAsync("yourloginapi", content);
        response.EnsureSuccessStatusCode();
        string AccessToken = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        /*Get Access Token End*/
        If(!string.IsNullOrEmpty(AccessToken))
        {
                var ticket = Startup.OAuthBearerOptions.AccessTokenFormat.Unprotect(AccessToken);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, ticket.Identity.Name), new Claim(ClaimTypes.NameIdentifier, ticket.Identity.GetUserId()) };
                var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { IsPersistent = true }, id);
                return RedirectToLocal(returnUrl);
            
       }
       ModelState.AddModelError("Error", "Invalid Authentication");
       return View();
    }
