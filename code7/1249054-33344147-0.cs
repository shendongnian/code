    public class ControllerBase : Controller 
    {
        protected bool useOverriddenMethod = true;
        
        protected override JsonResult Json(...) {
            if (useOverriddenMethod )
            {
                //do something here
            }
            else
            {
                return base.Json(...);
            }
        }
    }
