	class ApplicationUser : IApplicationUserProvider
	{
		private IDatabase _userService;
		public ApplicationUser(IDatabase userService) {
			_userService = userService;
		}
	
		public UserRoles GetRoles() {
			return _userService.GetUserPermission().GetRoles();
		}
	}
	
