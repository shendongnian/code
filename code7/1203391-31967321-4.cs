    [HttpPost]
    public async System.Threading.Tasks.Task Post(LoginInfo infos)
    {
            if (ValidateLogin(infos))
            {
                await Context.Authentication.SignInAsync(AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                }, 
                AuthenticationScheme)));
            }
     }
