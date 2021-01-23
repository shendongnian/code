        ApplicationUserManager _userManager;
    
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    
    // get your user here
    var currentUser = UserManager.Users...
                if (currentUser != null)
                {
                    var resultRemove = UserManager.RemovePassword(currentUser.Id);
                    var resultAdd = UserManager.AddPassword(currentUser.Id, model.NewPassword);
                    if (resultAdd.Succeeded && resultRemove.Succeeded)
                        //Send SMS here
                }
