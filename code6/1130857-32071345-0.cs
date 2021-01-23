    public class BootgridSortModelBinder<T> : System.Web.Mvc.IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			HttpRequestBase request = controllerContext.HttpContext.Request;
			Type typeParameterType = typeof(T);
			foreach (var prop in typeParameterType.GetProperties())
			{
				string dir = request.Form.Get(string.Format("sort[{0}]", prop.Name));
				if (!string.IsNullOrEmpty(dir))
				{
					return new BootgridSortDirection() { prop = prop.Name, direction = dir };
				}
			}
			return null;
		}
	}
