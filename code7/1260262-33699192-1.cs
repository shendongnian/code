    [AllowAnonymous]
    [HttpPost, Route("users/register")]
    public async Task<IHttpActionResult> RegisterClient(ClientRegisterBindingModel model)
    {
        try
        {
            var user = model.SomeFlag == "type1" ? new Client() : new Driver();
            SetType(user, model);
    
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
    
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
    
            return Ok();
        }
        catch
        {
            return InternalServerError();
        }
    }
    
    private void SetType(ApplicationUser appUser, ClientRegisterBindingModel model)
    {
        if(appUser is Client)
        {
            appUser = new Client()
            {
               UserName = model.Email,
               Email = model.Email,
               RegistrationDate = DateTime.Now
            }
        }
        //etc, check for other types
    }
