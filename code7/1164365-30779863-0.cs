    public async Task<IHttpActionResult> ConfirmEmail(ConfirmBindingModel model)
    {
    
        // If our userId or code are not supplied
        if (string.IsNullOrWhiteSpace(model.UserId) || string.IsNullOrWhiteSpace(model.Code))
        {
    
            // Add an error message to the ModelState
            ModelState.AddModelError("", "User Id and Code are required");
    
            // And return a BadRequest with the attached ModelState
            return BadRequest(ModelState);
        }
    
        //<--- in your create user method you set not password so this won't work
        // Set our password
        // var result = await this.UserService.ChangePasswordAsync(model.UserId, "", model.Password);
    
        //<--- instead you need to use AddPasswordAsync ----->
        var result = await this.UserService.AddPasswordAsync(model.UserId, model.Password);
    
        // If we didn't manage to create a password, return the error
        if (!result.Succeeded)
            return GetErrorResult(result);
    
        // Confirm our user
        result = await this.UserService.ConfirmEmailAsync(model.UserId, model.Code);
    
        // If we didn't manage to confirm the user, return the error
        if (!result.Succeeded)
            return GetErrorResult(result);
    
        // If we reach this point, everything was successful
        return Ok();
    }
