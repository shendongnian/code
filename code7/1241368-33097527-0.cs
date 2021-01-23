    public ActionResult Index(LoginViewModel requestResponseModel)
    { 
        // Has an email or password been entered?
        if (string.IsNullOrWhiteSpace(requestResponseModel.EmailOrPassword))
        {
              this.ModelState.AddModelError("EmailOrPassword", "Please enter an email or a password");
        }
        else
        {
            try
            {
                // Is the input a valid email address?
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                // Not valid email, is it a valid password?
                if (System.Text.regularExpressions.Regex.IsMatch(requestResponseModel.EmailOrPassword, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
                {
                    this.ModelState.AddModelError("EmailOrPassword", "Value entered is not a valid email address or password");
                }
            }
        }
        // Did it pass validation?
        if (this.ModelState.IsValid())
        {
            // Register the user here...
        }
        return View(requestResponseModel);
    }
