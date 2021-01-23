        class ControllerReferenceResolverFacade : IReferenceResolver
        {
            private IHttpContextAccessor _context;
            public ControllerReferenceResolverFacade(IHttpContextAccessor context)
            {
                _context = context;
            }
            public void AddReference(object context, string reference, object value)
            {
              if ((string)_context.HttpContext.RequestServices.GetService<ActionContext>().RouteData.Values["Controller"] == "HomeController")
                {
                    // pass off to HomeReferenceResolver
                }
                throw new NotImplementedException();
            }
