    public class MethodRequestBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
                            ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            //use the request object to make a call to your factory for the 
            //appropriate ActionMethod subtype you want to create, or however 
            //else you see fit.
            var curActionMethod = MyFactory.Get(request.QueryString);
            var boundObj = new MethodRequest()
            {
                Method = curActionMethod
            }
            
            return boundObj;
        }
    }
