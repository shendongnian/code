    public abstract class AuthorizationFilterBehaviorBase<TAttribute> : IAuthorizationFilter where TAttribute : Attribute
    {
        private readonly IContextAttributeInspector _attributeInspector;
        protected AuthorizationFilterBehaviorBase(IContextAttributeInspector attributeInspector)
        {
            _attributeInspector = attributeInspector;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            TAttribute attribute = null;
            if (_attributeInspector.TryGetActionAttribute(filterContext.ActionDescriptor, out attribute)
                || _attributeInspector.TryGetControllerAttribute(filterContext, out attribute))
            {
                OnAuthorizationBehavior(filterContext, attribute);
            }
        }
        protected abstract void OnAuthorizationBehavior(AuthorizationContext authorizationContext, TAttribute attribute);
    }
