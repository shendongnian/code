    public class MyModelBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            List<string> names = new List<string>();
            if (!string.IsNullOrEmpty(actionContext.Request.RequestUri.Query))
            {
                foreach (var item in actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value))
                {
                    if (item.Key.ToLower().StartsWith("name"))
                    {
                        //it's a "nameX" parameter so let's add it to the list
                        names.Add(item.Value);
                    }
                }
            }
            //this is what will be bound to "name" in the action method
            bindingContext.Model = names;
            return true;
        }
    }
