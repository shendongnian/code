	public sealed class RequestPermissionSelectorProxy : IPermission
	{
		private readonly PermissionRepository one;
		private readonly PermissionRepositoryTwo two;
		
		public RequestPermissionSelectorProxy(
			PermissionRepository one, PermissionRepositoryTwo two) {
			this.one = one;
			this.two = two;
		}
		
		// Here select the permission based on some runtime condition. Example:
		private IPermission Permission => 
			HttpContext.Current.Items["two"] == true ? two : one;
		
		public object PermissionMethod(object arguments) {
			return this.Permission.PermissionMethod(arguments);
		}
	}
