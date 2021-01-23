    User user = new User
    {
	    Roles = new List<UserRole>
	    {
          // Assume a constructor to set the Name
	      new UserRole("Role1"),
	      new UserRole("Role2")
	    }
    };
    UserViewModel uvm = Mapper.Map<User, UserViewModel>(user);
    Assert.AreEqual(2, uvm.RoleNames.Count);
    Assert.AreEqual("Role1", uvm.RoleNames.First());
    Assert.AreEqual("Role2", uvm.RoleNames.Last());
