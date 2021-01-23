    public class BasicHttpAuthorizeAttribute : AuthorizeAttribute
        { 
    protected override bool IsAuthorized(HttpActionContext actionContext)
            {
                if (Thread.CurrentPrincipal.Identity.Name.Length == 0)
                { 
                    // Get the header value
                    AuthenticationHeaderValue auth = actionContext.Request.Headers.Authorization;
                    // ensure its schema is correct
                    if (auth != null && string.Compare(auth.Scheme, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        // get the credientials
                        string credentials = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(auth.Parameter));
                        int separatorIndex = credentials.IndexOf(':');
                        if (separatorIndex >= 0)
                        {
                            // get user and password
                            string passedUserName = credentials.Substring(0, separatorIndex);
                            string passedPassword = credentials.Substring(separatorIndex + 1);
                            SimpleAES crypto = new SimpleAES();
                            string userName = crypto.DecryptString(ConfigurationManager.AppSettings.Get(Constants.SIMPLEUSERNAME));
                            string password = crypto.DecryptString(ConfigurationManager.AppSettings.Get(Constants.SIMPLEUSERPASSWORD));
    
                            // validate
                            if (passedUserName == userName && passedPassword == password)
                            {
                                Thread.CurrentPrincipal = actionContext.ControllerContext.RequestContext.Principal = new GenericPrincipal(new GenericIdentity(userName, "Basic"), new string[] { });
                            }
                        }
                    }
                }
                return base.IsAuthorized(actionContext);
            }
        }
