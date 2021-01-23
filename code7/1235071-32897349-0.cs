    var userDetails = new List<UserDetails>{ 
		new UserDetails(){ Id = 1, RoleId = 1 },
		new UserDetails(){ Id = 2, RoleId = 1 },
		new UserDetails(){ Id = 3, RoleId = 2 },
		new UserDetails(){ Id = 4, RoleId = 2 }
	};
	
	var userModels = new List<UserModel> {
		new UserModel { RoleId = 1, SelectedUserType = UserType.Primary },
		new UserModel { RoleId = 2, SelectedUserType = UserType.Secondary },
		new UserModel { RoleId = 3, SelectedUserType = UserType.Primary }
	};
