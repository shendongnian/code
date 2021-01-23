    public class UserNameModuleAuthenticator : IHttpModule{
        ...
        public void OnAuthenticateRequest(object source, EventArgs eventArgs){
          ...
          string authStr = app.Request.Headers["Authorization"];
          string username = ...; // from header 
          string password = ...; // from header 
          if (username == "gooduser" && password == "password")
                {
                    app.Context.User = new GenericPrincipal(new GenericIdentity(username, "Custom Provider"), null);
                }
                else
                {
                    DenyAccess(app);
                    return;
                }
