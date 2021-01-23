            private static bool AuthenticateUser(string credentials)
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));
    
                var credentialsArray = credentials.Split(':');
                var username = credentialsArray[0];
                var password = credentialsArray[1];
    
                if (!(username == "test" && password == "test"))
                {
                    return false;
                }
    
                var identity = new GenericIdentity(username);
                SetPrincipal(new GenericPrincipal(identity, string[]{})); //0 roles not null roles
    
                return true;
            }
    
            private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
            {
                var request = HttpContext.Current.Request;
                var authHeader = request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
    
                    // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                    if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                    {
                        bool userIsAuthenticated =AuthenticateUser(authHeaderVal.Parameter);
    //If not authenticated then user is not Authorized.
                        if (!userIsAuthenticated){
                           addUnauthorizedHeader()
                        }
                    }
    
                }
            }
           private static void addUnauthorizedHeader(){
                 response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
           }
