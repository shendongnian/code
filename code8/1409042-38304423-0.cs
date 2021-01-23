    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    public class DealManageCustomAuthorizeAttribute : AuthorizeAttribute
    {
        public DealManageCustomAuthorizeAttribute()
        {
            // Set the Super Admin and Deal User roles
            this.Roles = "Super Admin,Deal User";
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // This checks whether the user is logged in, and whether
            // they are in the Super Admin or Deal User role.
            var isAuthorized = base.IsAuthorized(actionContext);
            IPrincipal user = actionContext.ControllerContext.RequestContext.Principal;
            // Special case - user is in the Deal User role
            if (isAuthorized && user.IsInRole("Deal User"))
            {
                var queryString = actionContext.Request.GetQueryNameValuePairs()
                    .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
                // Ensure the query string contains the key "dealId"
                if (!queryString.ContainsKey("dealId"))
                {
                    return false;
                }
                Guid dealId;
                if (!Guid.TryParse(queryString["dealId"], out dealId))
                {
                    // If the Guid cannot be parsed, return unauthorized
                    return false;
                }
                // Now check whether the deal is authorized.
                var userId = user.Identity.GetUserId();
                return new Deal(Common.Common.TableSureConnectionString)
                    .CheckDealByIdAndUserId(dealId, userId);
            }
            return isAuthorized;
        }
    }
