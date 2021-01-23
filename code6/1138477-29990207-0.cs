    public class BaseController : Controller
    {
    	protected override void OnResultExecuting(ResultExecutingContext filterContext)
    	{
            List<categories> categories = db.categories.ToList();
            ViewBag.categories = categories;
    		base.OnResultExecuting(filterContext);
	    }
    }
