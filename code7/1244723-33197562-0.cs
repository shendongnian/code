	var currentUserId = User.Identity.GetUserId();
	// Look up existing record
	var personalInformation = _dbContext.PersonalInformation
                                        .FirstOrDefault(p => p.UserId == currentUserId);
	if (personalInformation == null)
	{
		// If not exists, create and attach new record
		personalInformation = _dbContext.PersonalInformation.Create();	
	}
	// Map incoming model properties to entity
	personalInformation.FirstName = model.FirstName;
	personalInformation.Address = model.Address;
	// ...
    // Add or update the entity in the database
	_dbContext.SaveChanges();
