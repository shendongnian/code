    // make sure email is not empty, valid, and unique
    private async Task ValidateEmailAsync(TUser user, List<string> errors)
    {
        var email = await Manager.GetEmailStore().GetEmailAsync(user).WithCurrentCulture();
        if (string.IsNullOrWhiteSpace(email))
        {
            errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.PropertyTooShort, "Email"));
            return;
        }
        try
        {
            var m = new MailAddress(email);
        }
        catch (FormatException)
        {
            errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.InvalidEmail, email));
            return;
        }
        var owner = await Manager.FindByEmailAsync(email).WithCurrentCulture();
        if (owner != null && !EqualityComparer<TKey>.Default.Equals(owner.Id, user.Id))
        {
            errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.DuplicateEmail, email));
        }
    }
