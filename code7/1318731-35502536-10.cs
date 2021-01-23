      protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.Result = Json(new ErrorApiResult("error", filterContext.Exception.Message));
        }
