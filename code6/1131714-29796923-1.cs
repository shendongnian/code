	public UserModel GetUserDetailsById(int userId)
	{
		using (var db = new klpm04222014Entities())
		{								 
			var user = db.klpm_user.SingleOrDefault(x => x.UserID == userId);
			if(user != null) 
			{
                // map the properties of your entity to the UserModel
				return new UserModel {
					UserID = user.UserID,
					...
				};
			}
			return null;
		}
	}
