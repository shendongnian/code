		public abstract class BaseController : Controller
		{
			protected override ViewResult View(string viewName, string masterName, object model)
			{
				if (string.IsNullOrEmpty(viewName)) 
                    viewName = (string)RouteData.Values["action"];
				string localizedViewName = $"{viewName}.{CultureInfo.CurrentCulture.Name}";
				bool hasLocalizedView = ViewEngines.Engines
					.FindPartialView(ControllerContext, localizedViewName)
					.View != null;
				return base.View(hasLocalizedView ? localizedViewName : viewName, masterName, model);
			}
		}
