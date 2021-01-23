    using System.Web.Mvc;
    
    namespace YourNameSpace
    {
        public class MyCustomModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                HttpRequestBase request = controllerContext.RequestContext.HttpContext.Request;
    
                Dictionary<string, int> test = new Dictionary<string, int>();
    
                test.Add("test[10]", int.Parse(request.Form["test[10]"]));
                test.Add("test[11]", int.Parse(request.Form["test[11]"]));
    
                return test;
            }
        }
    }
