    Notifications = 
    new OpenIdConnectAuthenticationNotifications
	{
		SecurityTokenValidated = async n =>
		{
			var id = n.AuthenticationTicket.Identity;
			var uid = id.FindFirst(ClaimTypes.NameIdentifier);
			var givenName = id.FindFirst(ClaimTypes.GivenName);
			var familyName = id.FindFirst(ClaimTypes.Surname);
			var roles = id.FindAll(ClaimTypes.Role);
			var rolesList = roles as IList<Claim> ?? roles.ToList();
			if (
				!rolesList.Any(
					c =>
						string.Equals(c.Value, RoleNames.ContentEditor,
							StringComparison.InvariantCultureIgnoreCase)))
				throw new HttpException(403,
					"You do not have any roles configured for the application");
			// create new identity and set name and role claim type
			var nid = new ClaimsIdentity(
				id.AuthenticationType,
				ClaimTypes.GivenName,
				ClaimTypes.Role);
			UpdateUserType(uid.Value, rolesList, applicationConfiguration.AuthorityUrl);
			nid.AddClaim(givenName);
			nid.AddClaim(familyName);
			nid.AddClaims(rolesList);
			nid.AddClaim(uid);
			nid.AddClaim(id.FindFirst(ClaimTypes.Email));
			n.AuthenticationTicket = new AuthenticationTicket(
				nid,
				n.AuthenticationTicket.Properties);
		}
	}
    private static void UpdateUserType(string uid, IList<Claim> roles, string providerName)
        {
            var userService = ApplicationContext.Current.Services.UserService;
            var oneUser = ApplicationContext.Current.Services.ExternalLoginService.Find(new UserLoginInfo(providerName, uid)).FirstOrDefault();
            if (oneUser == null)
                return;
            var user = userService.GetUserById(oneUser.UserId);
            if (user == null)
                return;
            if (
                roles.Any(
                    r => string.Equals(r.Value, RoleNames.Administrator, StringComparison.InvariantCultureIgnoreCase))
                && !string.Equals(user.UserType.Alias, UmbracoRoleNames.Administrator))
            {
                SetUserType(user, UmbracoRoleNames.Administrator, userService);
                return;
            }
            if (
                roles.Any(
                    r => string.Equals(r.Value, RoleNames.ContentEditor, StringComparison.InvariantCultureIgnoreCase))
                && !string.Equals(user.UserType.Alias, UmbracoRoleNames.ContentEditor))
            {
                SetUserType(user, UmbracoRoleNames.ContentEditor, userService);
                return;
            }
        }
    private static void SetUserType(Umbraco.Core.Models.Membership.IUser user, string alias, IUserService userService)
        {
            try
            {
                user.UserType = userService.GetUserTypeByAlias(alias);
                userService.Save(user);
            }
            catch (Exception e)
            {
                LogHelper.Error(typeof(ClassName), "Could not update the UserType of a user.", e);
            }
        }
