    public ActionResult Edit(int ID)
    {
      // Get all roles
	  IEnumerable<string> roles = new List<string>(){ "Administrator", "Gestor", "Supervisor", "SecurityManager", "Admin" };
      // Get the User
      User user = db.Users().Where(u => u.ID == ID).FirstOrDefault();
      // Get the user roles (if not included in User model
	  IEnumerable<UserRole> userRoles = db.UserRoles().Where(r => r.UserID == ID);
      // Create collection of all roles
	  List<RoleVM> allRoles = roles.Select(r => new RoleVM()
	  {
	    Name = r
	  }).ToList();
			
      // Set the ID and IsSelected properties based on the user roles
	  foreach(RoleVM role in allRoles)
	  {
		UserRole userRole = userRoles.FirstOrDefault(r => r.Role == role.Name);
		if (userRole != null)
		{
	      role.ID = userRole.ID;
		  role.IsSelected = true;
		}
      }
			
	  // Initialize the view model
	  UserVM model = new UserVM()
	  {
		ID = user.ID,
        Name = user.Name,
		Roles = allRoles
	  };
	  return View(model);
    }
