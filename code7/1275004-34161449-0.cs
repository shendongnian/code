    // Retrieve the system user ID of the user to impersonate.
    OrganizationServiceContext orgContext = new OrganizationServiceContext(_serviceProxy);
    _userId = (from user in orgContext.CreateQuery<SystemUser>()
              where user.FullName == "Kevin Cook"
              select user.SystemUserId.Value).FirstOrDefault();
    
    // To impersonate another user, set the OrganizationServiceProxy.CallerId
    // property to the ID of the other user.
    _serviceProxy.CallerId = _userId;
    // Use serviceProxy for any API calls and it will run as the above user
