    public async Task<IdentityResult> RegisterUser(AccountViewModels.RegisterViewModel userModel)
    {
        var result = await _userManager.CreateAsync(user, userModel.Password);
        await this.SendEmailConfirm(userModel.Email);
    
        return result;
    }
    
    public async Task SendEmailConfirm(string mail)
    {
        string subject = "Please confirm your Email for Chronicus";
        string body = "Hello"
        string email = user.Email;
    
        await _messageService.SendMail(mail, subject, body);
    }
    
