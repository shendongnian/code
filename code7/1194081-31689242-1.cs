	// NOTE: This could/should be automatically generated from the resources file
	public class Resources 
	{
		public class HomeResources
		{
			public string Title { get; set; }
			public string Keywords { get; set; }
			public string Description { get; set; }
			public string RSS { get; set; }
			public string ScriptsHeader { get; set; }
			public string ScriptsFooter { get; set; }
			public string Body { get; set; }
		}
		public HomeResources Home { get; set; }
		...
		// Other categorisations of resources
		...
	}
	public class Localisation
	{
		private Resources _resources;
		public Localisation(Resources resources)
		{
			_resources = resources;
		}
		public LocaliseText<TProperty>(Expression<Func<Resources, TProperty>> expr)
		{
			// Borrow functionality from MVC to get the string representation
			// of the expression property reference e.g.
			//    r => r.Home.Title   =>   "Home.Title"
			var propertyName = ExpressionHelper.GetExpressionText(expr);
			//.. Do your string resource lookup
		}
	}
