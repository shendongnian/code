     [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(string userName, string password)
        {
            var userManager = new LockingUserManager<MyUser, int>(new MyUserStore())
            {
                DefaultAccountLockoutTimeSpan = /* get from appSettings */,
                MaxFailedAccessAttemptsBeforeLockout = /* get from appSettings */
            };
    
            var user = await userManager.FindAsync(userName, password);
    
            if (user == null)
            {
                // bad username or password; take appropriate action
            }
    
            if (await _userManager.GetLockoutEnabledAsync(user.Id))
            {
                // user is locked out; take appropriate action
            }
    
            // username and password are good
            // mark user as authenticated and redirect to post-login landing page
        }
