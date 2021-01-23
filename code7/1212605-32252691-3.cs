    // Custom attribute for Basic authentication
    public class BasicAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private readonly string[] _permissionNames;
        public BasicAuthorizeAttribute()
        {
        }
        public BasicAuthorizeAttribute(params string[] permissionNames)
        {
            _permissionNames = permissionNames;
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // check if user has been already authorized
            if (base.IsAuthorized(actionContext))
                return true;
            var user = AuthenticateUser(actionContext);
            
            // here you can check roles and permissions
            return user != null;
        }
        private IUser AuthenticateUser(HttpActionContext context)
        {
            var request = context.Request;
            AuthenticationHeaderValue authHeader = request.Headers.Authorization;
            if (authHeader != null)
            {
                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeader.Parameter != null)
                    return AuthenticateUser(authHeader.Parameter);
            }
            return null;
        }
        private IUser AuthenticateUser(string credentials)
        {
            try
            {
                // parse values
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));
                var credentialsArray = credentials.Split(':');
                var username = credentialsArray[0];
                var password = credentialsArray[1];
                // authentication
                var membershipService = new IMembershipService();
                return membershipService.ValidateUser(username, password);
            }
            catch (Exception)
            {
                // Credentials were not formatted correctly.
                return null;
            }
        }
    }
