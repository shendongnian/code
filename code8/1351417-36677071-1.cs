    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        ApplicationGroupManager groupManager = new ApplicationGroupManager();
        if (Membership.ValidateUser(model.UserName, model.Password))
        {
            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            //Assign Roles to the current User
            ApplicationUser user = UserManager.FindByName(model.UserName);
            //If the user is registered in the system (ASP.NET Identity) add record to AspNetUsers table 
            if (user != null)
            {
                //Returns Group Id and Role Id by using User Id parameter
                var userGroupRoles = groupManager.GetUserGroupRoles("bfd9730e-2093-4fa0-89a2-226e301d831b"); 
                foreach (var role in userGroupRoles)
                {
                    string roleName = RoleManager.FindById(role.ApplicationRoleId).Name;
                    UserManager.AddToRole(user.Id, roleName);
                }
            }
            else
            {
                //crate new user
                //first retrieve user info from LDAP:
                // Create an array of properties that we would like and add them to the search object  
                string[] requiredProperties = new string[] { "samaccountname", "givenname", "sn", "mail", "physicalDeliveryOfficeName", "title" };
                var userInfo = CreateDirectoryEntry(model.UserName, requiredProperties);
                var newUser = new ApplicationUser();
                newUser.UserName = userInfo.GetDirectoryEntry().Properties["samaccountname"].Value.ToString();
                newUser.Name = userInfo.GetDirectoryEntry().Properties["givenname"].Value.ToString();
                newUser.Surname = userInfo.GetDirectoryEntry().Properties["sn"].Value.ToString();
                newUser.Email = userInfo.GetDirectoryEntry().Properties["mail"].Value.ToString();
                newUser.EmailConfirmed = true;
                newUser.PasswordHash = null;
                var result = await UserManager.CreateAsync(newUser);
                if (result.Succeeded)
                {
                    //If the user is created ...
                }
                //Assign user group (and roles)
                var defaultGroup = "751b30d7-80be-4b3e-bfdb-3ff8c13be05e";
                groupManager.SetUserGroups(newUser.Id, new string[] { defaultGroup });
            }
            return this.RedirectToAction("Index", "Issue");
        }
        this.ModelState.AddModelError(string.Empty, "Wrong username or password!");
        return this.View(model);
    }
    static SearchResult CreateDirectoryEntry(string sAMAccountName, string[] requiredProperties)
    {
        DirectoryEntry ldapConnection = null;
        try
        {
            ldapConnection = new DirectoryEntry("LDAP://OU=******, DC=******, DC=******", "acb@xyz.com", "YourPassword");
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            DirectorySearcher search = new DirectorySearcher(ldapConnection);
            search.Filter = String.Format("(sAMAccountName={0})", sAMAccountName);
            foreach (String property in requiredProperties)
                search.PropertiesToLoad.Add(property);
            SearchResult result = search.FindOne();
            //SearchResultCollection searchResultCollection = search.FindAll(); //You can also retrieve all information
            if (result != null)
            {                
                return result;
            }
            else {
                return null;
                //Console.WriteLine("User not found!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception caught:\n\n" + e.ToString());
        }
        return null;
    }
