     public static class SessionManager
        {
    
    
            public static object _Session_UserInfo
            {
    
                get
                {
    
                    if (HttpContext.Current.Session["isUser"] == null)
                    {
                        HttpContext.Current.Response.Redirect("Index?Expired=1");
                        return null;
                    }
    
                    else
                    {
                        return HttpContext.Current.Session["isUser"];
                    }
                }
    
    
                set
                {
                    HttpContext.Current.Session["isUser"] = value;
                
                
                }
    
            }
    
    
    
        }
