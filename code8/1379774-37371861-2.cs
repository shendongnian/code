    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
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
                //TODO Return true or false, whether you need to accept this request or not
            }
        }
    }
