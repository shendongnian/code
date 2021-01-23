      protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.Result = new ErrorApiResult("error", filterContext.Exception.Message);
        }
