    public void OnException(ExceptionContext filterContext)
    {
        //perform some custom action, e.g. logging
        _logger.Log(filterContext.Exception);
        //return a particular status
        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
