    public class MyActionFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            
            //Add other criterias and required null checkings here
            
            //Find the person id from action arguments
            int personID = Convert.ToInt32(actionContext.ActionArguments["personID"]);
            var _personRepo = new PersonRepository();
            
            //Get the controller instance that is running and set the Person property
            ((People)actionContext.ControllerContext.Controller).Person = _personRepo.GetPerson(personID); 
        }
    }
