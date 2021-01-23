    public class CustomizeAppDbcontextFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
    	    var dbcontext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();    
    	    var currentuser = HttpContext.Current.User;
    	    dbcontext.SavingChangesEventHandler = (sender, args) =>
                {
                    // use currentuser
                };	
        }    
    }
