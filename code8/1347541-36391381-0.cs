	class ApplicationUser : IApplicationUserProvider
	{
		private Lazy<UserPermissions> _userPermissions;
		public ApplicationUser(IDatabase userService) {
			_userPermissions = new Lazy<UserPermissions>(userService.GetUserPermission);
		}
	
		UserRoles GetRoles() {
			return _userPermissions.Value.GetRoles();
		}
	}
	
