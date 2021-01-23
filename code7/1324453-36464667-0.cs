    internal static class UserPermissions
	{
		public static bool CheckRole(Role role)
		{
			try {
				var p = new PrincipalPermission(null, role.ToString());
				p.Demand();
			}
			catch (SecurityException) {
				return false;
			}
			return true;
		}
		public static void AssertRole(Role role)
		{
			if (!CheckRole(role)) {
				throw new WebFaultException(HttpStatusCode.Unauthorized);
			}
		}
	}
    public enum Role
	{
		Administrator,
		Customer
	}
