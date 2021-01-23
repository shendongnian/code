        public async Task<IActionResult> Register(string returnUrl = null)
    {
        var externalPrincipal = await HttpContext.Authentication.AuthenticateAsync("Temp");
        //TODO Check external principal and retrieve claims from db or whatever needs to be done here.
        var claims = new List<Claim>()
            {
                new Claim("email", externalPrincipal.FindFirst(ClaimTypes.Email).Value)
            };
        var id = new ClaimsIdentity(claims, "password");
        await HttpContext.Authentication.SignInAsync("Cookie", new ClaimsPrincipal(id));
        await HttpContext.Authentication.SignOutAsync("Temp");
        return Redirect(returnUrl);
    }
    public async Task<IActionResult> LogInGoogle(string returnUrl = null)
    {
        var queryString = !string.IsNullOrWhiteSpace(returnUrl) ? $"?returnUrl={returnUrl}" : string.Empty;
        var props = new AuthenticationProperties() { RedirectUri = $@"Account/Register{queryString}" }; //new PathString(returnUrl)
        return await Task.Run<ChallengeResult>(() => new ChallengeResult("Google", props));
    }
