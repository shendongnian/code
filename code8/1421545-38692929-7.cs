	using(MyDbContext context = new MyDbContext())
	{
		UserInfo userInfo = .....;
        context.UserInfoes.Attach(userInfo);
		List<string> propertiesNotToUpdate = new List<string>
		{
			"UserId",
			"RegistrationDate"
		};
		context.SetPropertiesToModeified(userInfo, propertiesNotToUpdate);
		context.SaveChanges();
	}
