    protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
    
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
    
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
    
                    CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);
    
                    CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                    newUser.user_id = serializeModel.user_id;
                    newUser.username = serializeModel.username;
                    newUser.roles = serializeModel.roles;
                    newUser.form_token = serializeModel.form_token;
    
                    HttpContext.Current.User = newUser;
                }
            }
