    public OptionalAuthorizeAttribute()
    {
        
    }
    
    protected override bool AuthorizeCore(HttpContext httpContext){
                string username = HttpContext.Current.Session["username"].ToString();
                string password = HttpContext.Current.Session["password"].ToString();
    
                if (username == password)
                {
                    return true;
                }
                    return base.AuthorizeCore(httpContext);
        }
    }
