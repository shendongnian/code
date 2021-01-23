        public void ConfigureAuth(IAppBuilder app)
        {
            // These two are probably already referenced
        	app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        	app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        
            // Add this reference
        	app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        }
