     public override void OnActionExecuting( ActionExecutingContext filterContext)
          {
           
            if (true)
            {
                //Create your result
                filterContext.Result = new EmptyResult();
            }
            else
                base.OnActionExecuting(filterContext);
        }
