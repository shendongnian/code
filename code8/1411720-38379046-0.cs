    public class AuthorizeRoles : AuthorizeAttribute
        {
            private readonly List<string> _rolesAllowed;
    
            public AuthorizeRoles(string rolesAllowed)
            {
                this._rolesAllowed = rolesAllowed.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
    
            public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
            {            
                var controller = actionContext.ControllerContext.Controller;
    
                    if (!this._rolesAllowed.Contains("*"))
                    {
                        string errorMessage = "Authorization denied. Missing required role";
                        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                    }
                    
                }
                else
                {
                    string errorMessage = "Authorization denied. Request is missing context header";
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
    
                base.OnAuthorization(actionContext);
            }
