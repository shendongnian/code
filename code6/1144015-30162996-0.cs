    public class MyCustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
    
            string username = request.Form.Get("iptloginUserName");
            string password = request.Form.Get("iptloginPassWord");
            
            return new User
                       {
                           UserName = title,
                           Password = password
                       };
        }
    } 
    
