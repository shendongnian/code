	var validator = new PasswordValidator
	{
		RequiredLength = 6,
		RequireNonLetterOrDigit = false,
		RequireDigit = true,
		RequireLowercase = true,
		RequireUppercase = true
	};
	passwords.Add(GeneratePassword(validator));
	
	
	private static string GeneratePassword(PasswordValidator passwordValidator)
	{
		var rnd = new Random();
		while (true)
		{
			var password = Membership.GeneratePassword(passwordValidator.RequiredLength, 0);
			if ((passwordValidator.RequireDigit && !password.Any(char.IsDigit)) || (passwordValidator.RequireLowercase && !password.Any(char.IsLower)) || (passwordValidator.RequireUppercase && !password.Any(char.IsUpper)))
				continue;
			if (!passwordValidator.RequireNonLetterOrDigit) password = Regex.Replace(password, @"[^a-zA-Z0-9]", m => rnd.Next(0, 10).ToString());
			return password;
		}
	}
