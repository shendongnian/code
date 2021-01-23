        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (IsValid())
            {
                //do something
            }
            else
            {
                // You can throw any exception even custom.
                throw new AuthenticationException("User must be logged in to access this page.");
            }
        }
