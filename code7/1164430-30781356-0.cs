    private void Authenticate(string login)
    {
      FormsAuthentication.Initialize();
    
      var ticket = new FormsAuthenticationTicket(1,
                                                 login,
                                                 DateTime.Now,
                                                 DateTime.Now.AddHours(3), // time of user's session .. add more if you need
                                                 false,
                                                 null);
    
      var encryptedTicket = FormsAuthentication.Encrypt(ticket);
    
      if (!FormsAuthentication.CookiesSupported)
      {
          FormsAuthentication.SetAuthCookie(encryptedTicket, false);
      }
      else
      {
          HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
    
          authCookie.Expires = ticket.Expiration;
    
          System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
      }  
    }
    
