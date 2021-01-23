    using (TransactionScope scope = new TransactionScope())
    {
        var result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await this.UserManager.AddToRoleAsync(user.Id, model.Role.ToString());
            string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");
            return View("DisplayEmail");
        }
        scope.Complete();
    }
