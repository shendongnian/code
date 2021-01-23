    namespace MyWebsite.API.Attributes
    {
        public class RESTAuthorizeAttribute : AuthorizeAttribute
        {
            private ISecurityRepository _repository;
    
            public RESTAuthorizeAttribute()
                : this(new SecurityRepository())
            {
    
            }
    
            public RESTAuthorizeAttribute(ISecurityRepository repository)
            {
                _repository = repository;
            }
    
            private const string _securityToken = "token";
        
            // This function actually decides whether this request will be accepted or not
            protected override bool IsAuthorized(HttpActionContext actionContext)
            {
                try
                {
                    HttpRequestBase request = actionContext.RequestContext.HttpContext.Request;
                    string token = request.Params[_securityToken];
                    string ip = _repository.GetIP(request);
    
                    return _repository.IsTokenValid(token, ip, request.UserAgent);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
