    [AllowAnonymous]
        public class ErroHttpController : Controller
        {
            [Route("RequestError")]
            public ActionResult RequestError()
            {
                Response.StatusCode = 400;
                return View();
            }
            
            [Route("NotFound")]
            public ActionResult NotFound()
            {
                Response.StatusCode = 404;
                return View();
            }
            
            [Route("InternalError")]
            public ActionResult InternalError()
            {
                Response.StatusCode = 500;
                return View();
            }
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                Response.TrySkipIisCustomErrors = true;
                base.OnActionExecuting(filterContext);
            }
        }
    }
