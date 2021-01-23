    public static MyAuthenticationTicket  GetIMyUserTicket()
    {
        //Get custom user data object from forms auth cookie
        MyAuthenticationTicket  result= null;
        if (HttpContext.Current.User == null)
            return null;
        if (!HttpContext.Current.Request.IsAuthenticated)
            return null;
        FormsIdentity ident = (FormsIdentity)HttpContext.Current.User.Identity;
        if (ident == null)
            return null;
        FormsAuthenticationTicket ticket = ident.Ticket;
        if (ticket == null)
            return null;
        if (!FormsAuthentication.CookiesSupported)
        {               
            //If cookie is not supported for forms authentication, then the 
            //authentication ticket is stored in the Url, which is encrypted.
            //So, decrypt it
            ticket = FormsAuthentication.Decrypt(ident.Ticket.Name);
                    
        }
                    
        string userDataString = ticket.UserData;
        if(!String.IsNullOrEmpty(userDataString))
            result= new MyAuthenticationTicket(userDataString);
    
        return result;       
    }
