    if (!String.IsNullOrWhiteSpace(searchString))
	{
		DateTime dateOfRegistration;
		bool isDateTime = DateTime.TryParse(searchString, out dateOfRegistration);
		if (isDateTime)
		{	
			users = users.Where(user => user.date_of_register == dateOfRegistration);
		}
		else 
		{
			users = users.Where(a => a.username.Contains(searchString));
		}
	}
