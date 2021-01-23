    public class CustomControllerFactory : DefaultControllerFactory
    {
		 public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            string controllername = requestContext.RouteData.Values["controller"].ToString();       
            Type controllerType = Type.GetType(string.Format("Namespace.{0}",controllername));
            IController controller = Activator.CreateInstance(controllerType) as IController;
            return controller;
        
        }
	}
