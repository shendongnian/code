	var allowedCredentials = new List<Tuple<String, String>> { 
		new Tuple<String, String>("Rob", "Robspassword"), 
		new Tuple<String, String> ("SomeoneElse", "SomeoneElsespassword" 
	};
	var inputCredentials = new List<string> { "Rob","Robspassword","Rob","Notrobspassword" };
		
	var usernames = inputCredentials.Where((s, i) => { return i % 2 == 0; });
	var passwords = inputCredentials.Where((s, i) => { return i % 2 != 0; });
	
	var userPasswords = usernames.Zip(passwords, (l, r) => new { username = l, password = r });
	foreach(var userPassword in userPasswords) {
		if (allowedCredentials.Any(ac => ac.Item1 == userPassword.username 
               && ac.Item2 == userPassword.password)
		{
			//Valid
		}
		
	}
