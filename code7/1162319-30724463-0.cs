        var userManager = owinContext.GetUserManager<ApplicationUserManager>();
        Parallel.ForEach (bulkUser.BulkUserDetails, bulkUserDetail => 
        {       
            //Do you really need to make this userProfile as its not used
            var userProfile = new UserProfile();
            userProfile.Username = bulkUserDetail.Username;
            AspNetUser newUser = new AspNetUser
            {
                UserName = userProfile.Username,
                Email = bulkUserDetail.Email,
                LastPasswordChangedDate = null,
            };
            var creationResult = userManager.Create(newUser);
            if (creationResult.Succeeded)
            {
                string token = userManager.GeneratePasswordResetToken(newUser.Id);
            }
        })
