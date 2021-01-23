    public class CustomCredentialsAuthProvider : CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, 
            string userName, string password)
        {
            //Add here your custom auth logic (database calls etc)
            //Return true if credentials are valid, otherwise false
        }
    
        public override IHttpResult OnAuthenticated(IServiceBase authService, 
            IAuthSession session, IAuthTokens tokens, 
            Dictionary<string, string> authInfo)
        {
            //Fill IAuthSession with data you want to retrieve in the app eg:
            session.FirstName = "some_firstname_from_db";
            //...
    
            //Call base method to Save Session and fire Auth/Session callbacks:
            return base.OnAuthenticated(authService, session, tokens, authInfo);
    
            //Alternatively avoid built-in behavior and explicitly save session with
            //authService.SaveSession(session, SessionExpiry);
            //return null;
        }
    }
