	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new CustomRequireHttpsAttribute());
			filters.Add(new CustomAuthorizeAttribute(Role = "User"));
		}
	}
