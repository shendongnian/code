    protected void Session_Start()
            {            
                if (Session["Username"] != null)
                {
                    //Redirect to Welcome Page if Session is not null  
                    HttpContext.Current.Response.Redirect("~/WelcomeScreen", false);
    
                }
                else
                {
                    //Redirect to Login Page if Session is null & Expires                   
                    new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Login" } });
                }
            }
