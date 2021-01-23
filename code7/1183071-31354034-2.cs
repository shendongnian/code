    public class MyActionSelectorAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            HttpRequestBase request = controllerContext.RequestContext.HttpContext.Request;
            // your custom method selection logic goes here
            // select method based on previously searched term
            if (request.QueryString["foo"] != null && methodInfo.Name == "Foo")
            {
                return true;
            }
            else if (request.QueryString["foo2"] != null && methodInfo.Name == "Foo2")
            {
                return true;
            }
            return false;
        }
    }
