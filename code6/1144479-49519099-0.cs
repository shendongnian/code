    public void ConfigureAuth(IAppBuilder app) {
    	app.CreatePerOwinContext(ApplicationDbContext.Create);
    	app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    	app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
    	app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
    	app.CreatePerOwinContext<ApplicationGroupManager>(ApplicationGroupManager.Create);
    	app.CreatePerOwinContext<ApplicationDepartmentManager>(ApplicationDepartmentManager.Create);
    
    	app.UseCookieAuthentication(new CookieAuthenticationOptions {
    		AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    		LoginPath = new PathString("/Login"),
    		Provider = new CookieAuthenticationProvider {
    			
    			OnValidateIdentity = delegate(CookieValidateIdentityContext context) {
    				var stampValidator = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
    					validateInterval: TimeSpan.FromMinutes(15),
    					regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
    					getUserIdCallback: (id) => (id.GetUserId<int>())
    				);
    				Task result = stampValidator.Invoke(context);
    
    				bool found_custom_expiration = false;
    				int timeout = STATIC_CONFIG.DefaultSessionExpireMinutes;
    				DBHelper.Query(delegate (SqlCommand cmd) {
    					cmd.CommandText = @"
    						SELECT [value] 
    						FROM [dbo].[Vars] 
    						WHERE [FK_Department] = (
    							SELECT [Id] FROM [dbo].[ApplicationDepartments] WHERE [title] = 'Default'
    						) 
    						AND [name]='Session Timeout'
    					";
    					return cmd;
    				}, delegate (SqlDataReader reader) {
    					timeout = reader["value"].ToInt32();
    					found_custom_expiration = true;
    					return false;
    				});
    				if (found_custom_expiration) {
    					// set it at GLOBAL level for all users.
    					context.Options.ExpireTimeSpan = TimeSpan.FromMinutes(timeout);
    					// set it for the current user only.
    					context.Properties.ExpiresUtc = context.Properties.IssuedUtc.Value.AddMinutes(timeout);
    				}
    				// store it in a claim, so we can grab the remaining time later.
    				var expireUtc = context.Properties.ExpiresUtc;
    				var claimType = "ExpireUtc";
    				var identity = context.Identity;
    				if (identity.HasClaim(c => c.Type == claimType)) {
    					var existingClaim = identity.FindFirst(claimType);
    					identity.RemoveClaim(existingClaim);
    				}
    				var newClaim = new System.Security.Claims.Claim(claimType, expireUtc.Value.UtcTicks.ToString());
    				context.Identity.AddClaim(newClaim);
    				return result;
    			}
    		},
    		SlidingExpiration = true,
    		// here's the default global config which was seemingly unchangeable.. 
    		ExpireTimeSpan = TimeSpan.FromMinutes(STATIC_CONFIG.DefaultSessionExpireMinutes)
    	});
    
    	ApplicationHandler.OwinStartupCompleted();
    
    }
