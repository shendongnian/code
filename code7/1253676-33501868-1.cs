    public class AuthenticateUser : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext context)
            {
                //Do session check.
    			if (HttpContext.Current.Session["Id"] == null || String.IsNullOrEmpty(HttpContext.Current.Session["Id"].ToString()))
                {
                    HttpContext.Current.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult { Data = new { Status = HttpStatusCode.Forbidden, LogonRequired = true, result = "Session Expired" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
    					//redirect to login page
                        UrlHelper oUrl = new UrlHelper(HttpContext.Current.Request.RequestContext);
                        string s = oUrl.Action("", "UserInfo/");
                        HttpContext.Current.Response.Redirect(s);
                    }
                }
    			
    			//If usertype is User then allow it. If user type is admin then return redirect.
    			
    			//Redirect code if admin
    			UrlHelper oUrl = new UrlHelper(HttpContext.Current.Request.RequestContext);
    			string s = oUrl.Action("", "UserInfo/");
    			HttpContext.Current.Response.Redirect(s);
    			
            }
        }
