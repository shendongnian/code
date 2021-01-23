	public class PerRequestCacheDatabaseDecorator : IDatabase
	{
		private IDatabase _decoratee;
		
		public PerRequestCacheDatabaseDecorator(IDatabase decoratee) {
			_decoratee = decoratee;
		}
		
		public UserPermissions GetUserPermission() {
			var items = HttpContext.Current.Items;
			if (items["permissions"] == null)
				items["permissions"] = _decoratee.GetUserPermission();
			return (UserPermissions)items["permissions"];
		}
	}
