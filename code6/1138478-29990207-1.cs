    public class BaseController : Controller
    {
    	protected override void OnResultExecuting(ResultExecutingContext filterContext)
    	{
            // In case you're doing any AJAX calls there's no sense in
            // incurring the overhead of filling the ViewBag.
            if(!Request.IsAjaxRequest)
            {
                List<categories> categories = db.categories.ToList();
                ViewBag.categories = categories;
        		base.OnResultExecuting(filterContext);
            }
	    }
    }
