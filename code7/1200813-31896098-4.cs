    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    
    namespace ProductsApp.WebApiExtensions
    {
        public class IdentityWhiteListAuthorizationAttribute : System.Web.Http.AuthorizeAttribute
        {
            public IdentityWhiteListAuthorizationAttribute()
            {
            }
    
            private string CurrentActionName { get; set; }
    
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                this.CurrentActionName = actionContext.ActionDescriptor.ActionName;
                base.OnAuthorization(actionContext);
            }
    
            protected override bool IsAuthorized(HttpActionContext actionContext)
            {
    
                var test1 = System.Threading.Thread.CurrentPrincipal;
                var test2 = System.Security.Principal.WindowsIdentity.GetCurrent();
    
                ////string userName = actionContext.RequestContext.Principal.Name;/*  Web API v2  */
                string dingDingDingUserName = string.Empty;
                ApiController castController = actionContext.ControllerContext.Controller as ApiController;
                if (null != castController)
                {
                    dingDingDingUserName = castController.User.Identity.Name;
                }
            string status = string.Empty;
            if (string.IsNullOrEmpty(dingDingDingUserName))
            {
                status = "Not Good.  No dingDingDingUserName";
            }
            else
            {
                status = "Finally!";
            }
    
                return true;
            }
        }
    }
