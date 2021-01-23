    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {    
            // Authenticate (somehow) and retrieve the ID
            int id = Authentication.SomeMethod();
            ((MyController)filterContext.Controller).Id = id; 
            //Assign the Id by casting the controller (you might want to add a if ... is MyController before casting)
        }
    }
