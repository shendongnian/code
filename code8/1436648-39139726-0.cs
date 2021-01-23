    [HttpPost]
    [AllowAnonymous]
    [Route("ForgotPassword")]
    public async Task<HttpResponseMessage> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await UserManager.FindByNameAsync(model.Email);
            //if (user == null ||!(await UserManager.IsEmailConfirmedAsync(user.Id)))
            if (user == null)
            {
                return Ok();
            }
            var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            var callbackUrl = Url.Link("Default", new { Controller = "Account", Action = "ResetPassword", code = code });
            /*await UserManager.SendEmailAsync(user.Id, "Reset Password",
               "Please reset your password by clicking here : <a href=\""+ callbackUrl +"\">link</a>"); */
            await UserManager.SendEmailAsync(user.Id, "Reset Password",$"{callbackUrl}");
            
    		var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("http://www.yourNewDomain.com");
            return response;
        }
    	
        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
