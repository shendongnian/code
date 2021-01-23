    private async Task SendEmailConfirmation(User user)
    {
        string token = await this._userManager.GenerateEmailConfirmationTokenAsync(user);
        string callbackUrl = this._urlHelper.Action("EmailConfirmed", "Account", new ConfirmTokenViewModel(user.Id, token), protocol: this._contextAccessor.HttpContext.Request.Scheme);
    
        await this._emailService.SendAsync(to: user.Email,
                subject: "Confirm your account",
                body: "Please confirm your e-mail by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
    }
