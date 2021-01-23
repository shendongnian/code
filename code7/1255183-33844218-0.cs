    var credentials = client.ClientCredentials.UserName;
    var userNameProperty = credentials.GetType()
		.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
		.FirstOrDefault(p => p.Name.ToLower() == "username");
    if (userNameProperty != null)
		userNameProperty.SetValue(credentials, Options.UserName);
    var passwordProperty = credentials.GetType()
		.GetField("password", BindingFlags.NonPublic | BindingFlags.Instance);
    if (passwordProperty != null)
		passwordProperty.SetValue(credentials, Options.Password);
