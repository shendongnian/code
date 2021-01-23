    public IHttpActionResult Get([ModelBinder(typeof(GuidParserModelBinder))] Guid? id = null)
    {
	    return Json(id);
    }
    public class GuidParserModelBinder : IModelBinder
	{
		public bool BindModel(HttpActionContext actionContext, 
            ModelBindingContext bindingContext)
		{
			if (bindingContext.ModelType != typeof (Guid?))
				return false;
			var value = bindingContext.ValueProvider.GetValue("id");
			var rawValue = value.RawValue.ToString();
			if (string.IsNullOrWhiteSpace(rawValue))
				return false;
			Guid guid;
			if (Guid.TryParse(rawValue, out guid))
			{
				bindingContext.Model = guid;
				return true;
			}
			
			// throw exception or logic here
			return false;
		}
	}
