    [HttpPost]
    public async Task<ActionResult> ResetPassword(Models.PasswordResetForm model)
    {
        try
        {
            // Call your email sending code...
        }
        catch(MyCustomEmailException ex)
        {
            // Remember to log the exception
            ModelState.AddModelError(string.Empty, "We're sorry, we could not complete this request. Please wait a moment and then try again");
        }
    
        return View(model);
    }
