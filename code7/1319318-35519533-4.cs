    public ApplicationUser User
        {
            get
            {
                return UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());
            }
            set
            {
                User = value;
            }
        }
