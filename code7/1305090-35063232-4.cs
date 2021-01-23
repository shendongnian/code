    public async Task<IdentityResult> RegisterUser(AccountViewModels.RegisterViewModel userModel)
    {
        var result = await _userManager.CreateAsync(user, userModel.Password);
        await this.SendEmailConfirm(userModel.Email);
    
        return result;
    }
    
    public Task SendEmailConfirm(string mail)
    {
        string subject = "Please confirm your Email for Chronicus";
        string body = "Hello"
        string email = user.Email;
    
        return _messageService.SendMail(mail, subject, body);
    }
    
