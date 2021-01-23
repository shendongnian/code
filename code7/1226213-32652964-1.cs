        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    /* we found the cookie set in the HomeController-Index (which simulates a user-successful login */
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    Employee empFromCookie = JsonConvert.DeserializeObject<Employee>(authTicket.UserData);
                    if (null == empFromCookie)
                    {
                        throw new ArgumentNullException("Employee did not serialize from Cookie correctly.");
                    }
                    /* so we know the simulation of the user-login "passed" because the cookie exists..lets set the MyCustomClaimsPrincipal */
                    MyCustomClaimsIdentity iid = new MyCustomClaimsIdentity(new GenericIdentity("I_Started_In_Application_PostAuthenticateRequest.MyCustomClaimsIdentity.invokeFormsAuthenticationTicketCode = true"));
                    MyCustomClaimsPrincipal princ = new MyCustomClaimsPrincipal(iid);
                    Thread.CurrentPrincipal = princ;
                    HttpContext.Current.User = princ;
                }
               
        }
