    public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordBindingModel model)
    {
        var user = await UserManager.FindByNameAsync(model.UserName);
        if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
        {
            IdentityResult result = new IdentityResult("Username not found");
            return GetErrorResult(result);
        }
    }
