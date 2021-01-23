    var entity = new UDetails()
	{
		// ...
		
        Email = User.Identity.Name,
        RegesterDate = DateTime.Now,
        UDetailsId = User.Identity.GetUserId()		
		// ...
	};
