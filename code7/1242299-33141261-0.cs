    public BaseController()
    {
       // Check if variable exist in session
       // else check if patId is sent through request
       // then save it in session
       System.Web.HttpContext.Current.Session["PatId"] = System.Web.HttpContext.Request.Form["patId"];
       // perform remaining calculation
    }
