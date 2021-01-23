      public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
        if((string)filterContext.RouteData.Values["action"]=="Delete") //check if its delete action
    {
            if (db.MyDatas.Find(a=>a.ModelCreator.trim()==Context.User.Identity.Name.trim())==null)
            {
                    Response.Redirect("~/Home"); //or whatever u want to give for unauthorized
            }
            
        }
    }
