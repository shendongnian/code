    public void OnException(System.Web.Mvc.ExceptionContext context)
    {
        if (context.Exception is UnauthorizedAccessException)
        {
            // Redirect to login page again
            filterContext.Result = this.RedirectToAction("Login", "Account");
            context.ExceptionHandled = true;
        }
        base.OnException(filterContext);
    }
