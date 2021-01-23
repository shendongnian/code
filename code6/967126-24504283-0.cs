    public class BaseController : Controller
    {
       public bool isGlobal { get; private set; }
       protected override void Execute(RequestContext requestContext)
       {
          this.isGlobal = requestContext.HttpContext.Request.QueryString["global"] == null ? false : true;
          base.Execute(requestContext);
       }
    }
