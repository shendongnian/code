    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        private static readonly char[] SplitParameter = new char[1] {','};
        private string firstNames;
        private string[] firstNamesSplit = new string[0];
        public string FirstNames 
        {
            get { return this.firstNames ?? string.Empty; }
            set
            {
                this.firstNames = value;
                this.firstNamesSplit = SplitString(value);
            }
        }
        /// <summary> Called when a process requests authorization. </summary>
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
            {
                throw new InvalidOperationException("Cannot use with a ChildAction cache");
            }
            if (filterContext.ActionDescriptor.IsDefined(typeof (AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof (AllowAnonymousAttribute), true))
            {
                return;
            }
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
                cache.SetProxyMaxAge(new TimeSpan(0L));
                cache.AddValidationCallback(this.CacheValidateHandler, null);
            }
            else
                this.HandleUnauthorizedRequest(filterContext);
        }
        /// <summary> When overridden, provides an entry point for custom authorization checks. </summary>
        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated) return false;
            string claimValue = ClaimsPrincipal.Current.FindFirst("FirstName").Value;
            return this.firstNamesSplit.Length <= 0 ||
                   this.firstNamesSplit.Contains(claimValue, StringComparer.OrdinalIgnoreCase);
        }
        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = this.OnCacheAuthorization(new HttpContextWrapper(context));
        }
        /// <summary> Processes HTTP requests that fail authorization. </summary>
        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
        /// <summary>  Called when the caching module requests authorization. </summary>
        /// <returns>  A reference to the validation status.  </returns>
        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            return !this.AuthorizeCore(httpContext)
                ? HttpValidationStatus.IgnoreThisRequest
                : HttpValidationStatus.Valid;
        }
        private string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original)) return new string[0];
            return original.Split(SplitParameter)
                .Select(splitItem => new
                {
                    splitItem,
                    splitItemTrimmed = splitItem.Trim()
                })
                .Where (value => !string.IsNullOrEmpty(value.splitItemTrimmed))
                .Select(value => value.splitItemTrimmed).ToArray();
        }
    }
