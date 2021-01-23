       public class AuthenticationFilter : AuthorizationFilterAttribute
        {
            [Dependency]
            public ILoginService LoginService { get; set; }
    
            /// <summary>
            /// read requested header and validated
            /// </summary>
            /// <param name="actionContext"></param>
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                var identity = FetchFromHeader(actionContext);
    
                if (identity != null)
                {
                    if (LoginService.TokenAuthentication(identity))
                    {
                        CurrentThread.SetPrincipal(new GenericPrincipal(new GenericIdentity(identity), null), null, null);
    					
                        //IPrincipal principal = new GenericPrincipal(new GenericIdentity(identity), new string[] { "myRole" });
                        //Thread.CurrentPrincipal = principal;
                        //HttpContext.Current.User = principal;				
                    }
                    else
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        return;
                    }
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    return;
                }
                base.OnAuthorization(actionContext);
            }
    
            /// <summary>
            /// retrive header detail from the request 
            /// </summary>
            /// <param name="actionContext"></param>
            /// <returns></returns>
            private string FetchFromHeader(HttpActionContext actionContext)
            {
                string requestToken = null;
    
                var authRequest = actionContext.Request.Headers.Authorization;
                if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                    requestToken = authRequest.Parameter;
    
                return requestToken;
            }
        }
