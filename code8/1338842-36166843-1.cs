    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Linq;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    public class ConfigAuthorizationFilter : AuthorizeAttribute
    {
        // Hide users and roles, since we aren't using them here.
        [Obsolete("Not applicable in this class.", true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public string Roles { get; set; }
        [Obsolete("Not applicable in this class.", true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public string Users { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Pass the current action descriptor to the AuthorizeCore
            // method on the same thread by using HttpContext.Items
            filterContext.HttpContext.Items["ActionDescriptor"] = filterContext.ActionDescriptor;
            base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            var actionDescriptor = httpContext.Items["ActionDescriptor"] as ActionDescriptor;
            if (actionDescriptor != null)
            {
                var authorizeAttribute = this.GetConfigAuthorizeAttribute(actionDescriptor);
                // If the authorization attribute exists
                if (authorizeAttribute != null)
                {
                    // Ensure the user is logged in
                    IPrincipal user = httpContext.User;
                    if (!user.Identity.IsAuthenticated)
                    {
                        return false;
                    }
                    // Lookup the Web.Config settings
                    string users = ConfigurationManager.AppSettings[authorizeAttribute.UsersConfigurationKey];
                    string roles = ConfigurationManager.AppSettings[authorizeAttribute.RolesConfigurationKey];
                    string[] usersSplit = SplitString(users);
                    string[] rolesSplit = SplitString(roles);
                    // Run the authorization based on the configuration values
                    if (usersSplit.Length > 0 && !usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                    if (rolesSplit.Length > 0 && !rolesSplit.Any(user.IsInRole))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }
        private ConfigAuthorizeAttribute GetConfigAuthorizeAttribute(ActionDescriptor actionDescriptor)
        {
            ConfigAuthorizeAttribute result = null;
            // Check if the attribute exists on the action method
            result = (ConfigAuthorizeAttribute)actionDescriptor
                .GetCustomAttributes(attributeType: typeof(ConfigAuthorizeAttribute), inherit: true)
                .SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            // Check if the attribute exists on the controller
            result = (ConfigAuthorizeAttribute)actionDescriptor
                .ControllerDescriptor
                .GetCustomAttributes(attributeType: typeof(ConfigAuthorizeAttribute), inherit: true)
                .SingleOrDefault();
            return result;
        }
        internal static string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return new string[0];
            }
            return (from piece in original.Split(new char[] { ',' })
                    let trimmed = piece.Trim()
                    where !string.IsNullOrEmpty(trimmed)
                    select trimmed).ToArray<string>();
        }
    }
