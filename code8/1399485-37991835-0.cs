    [HttpGet]
    public IActionResult ServerError()
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
             var exception = exceptionHandlerFeature.Error;
             
             //TODO: log the exception
        }
        return View("500");
    }
