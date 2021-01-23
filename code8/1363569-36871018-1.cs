    public override void OnActionExecuting(ActionExecutingContext context)
    {     
        if( YourCodeToCheckWhetherUserIsAuthenticatedHere()==false)
        {  
          var url = new UrlHelper(context.Controller.ControllerContext.RequestContext)
                                                       .Action("Login", "Account");
          if (context.HttpContext.Request.IsAjaxRequest())
          {
            context.Result = new JsonResult { Data = new { LoginUrl = url} };
          }
          //to do : Non ajax request. keep your existing code
      }
    }
