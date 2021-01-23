	string userDirectory = "\\Users\\uploads " + User.Identity.Name + " " + User.Identity.GetUserId();
	if (!Directory.Exists(userDirectory))
	{
		Directory.CreateDirectory(userDirectory);
	}
