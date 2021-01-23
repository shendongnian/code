    public ActionResult GetRoles()
    		{
    		    var userRoles = new List<RolesViewModel>();
                var context = new ApplicationDbContext();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
          
    		    //Get all the usernames
                foreach (var user in userStore.Users)
    		    {
    		        var r = new RolesViewModel
    		        {
    		            UserName = user.UserName
    		        };
    		        userRoles.Add(r);
    		    }
    		    //Get all the Roles for our users
                foreach (var user in userRoles)
    		    {
    		        user.RoleNames = userManager.GetRoles(userStore.Users.First(s=>s.UserName==user.UserName).Id);
    		    }
    
    		    return View(userRoles);
    		}
