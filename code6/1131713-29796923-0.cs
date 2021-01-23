	public UserModel GetUserDetailsById(int userId)
	{
		using (var db = new klpm04222014Entities())
		{
			 return db.klpm_user.Select(x => new UserModel 
											 {
                                                // map whatever properties you need in your UserModel
												UserID = x.UserID,
												...
											 }).Single(x => x.UserID == userId);
		}
	}
