    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
     public ActionResult Login(string txtUserName, string txtPassword, string returnUrl)
          {
              string error;
              try
              {
                  PrincipalContext context = new PrincipalContext(ContextType.ApplicationDirectory, "M0I:389", "CN=Elise,DC=App,DC=com", ContextOptions.Negotiate);
                  
                  bool auth = context.ValidateCredentials(
                                  String.Format("CN={0},CN=Users,CN=Elise,DC=App,DC=com",
                                                txtUserName),
                                  txtPassword,
                                  ContextOptions.SimpleBind);
    //get all users groups
                  UserPrincipal user = UserPrincipal.FindByIdentity(context, txtUserName);
                  if (user != null)
                  {
                      PrincipalSearchResult<Principal> authgroups = user.GetAuthorizationGroups();
                      // do your checking with the auth groups that the user has - against your list 
                      foreach (var item in authgroups)
                      {
                          string x = item.Name;
                      }
                  }
                  if (true == auth)
                  {
                      // Create the authetication ticket
                      FormsAuthenticationTicket authTicket =
                          new FormsAuthenticationTicket(1,  // version
                                                        txtUserName,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(60),
                                                        false, "Administrators");
                      // Now encrypt the ticket.
                      string encryptedTicket =
                        FormsAuthentication.Encrypt(authTicket);
                      // Create a cookie and add the encrypted ticket to the
                      // cookie as data.
                      HttpCookie authCookie =
                                   new HttpCookie(FormsAuthentication.FormsCookieName,
                                                  encryptedTicket);
                      // Add the cookie to the outgoing cookies collection.
                      Response.Cookies.Add(authCookie);
                      if (!string.IsNullOrEmpty(returnUrl))
                      {
                          return Redirect(returnUrl);
                      }
                      else
                      {
                          Response.Redirect(
                                    FormsAuthentication.GetRedirectUrl(txtUserName,false));
                      }
                  }
                  else
                  {
                      error =
                           "Authentication failed, check username and password.";
                      ModelState.AddModelError(string.Empty, error);
                      ViewBag.ReturnUrl = returnUrl;
                  }
              }
              catch (Exception ex)
              {
                  error = "Error authenticating. " + ex.Message;
                  ModelState.AddModelError(string.Empty, error);
                  ViewBag.ReturnUrl = returnUrl;
              }
              return Redirect(returnUrl);
          }
