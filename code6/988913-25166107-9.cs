     if (filterContext.HttpContext.Request.IsAjaxRequest())
     {
          filterContext.HttpContext.Response.StatusCode = 403;
          filterContext.Result = new JsonResult { Data = "LogOut" };
     }
     else
     {
          filterContext.Result = new RedirectResult("~/Home/Index");
     }
