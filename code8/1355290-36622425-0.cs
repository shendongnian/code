    class DynamicAuthorizeAttribute : AuthorizeAttribute {
        protected void AuthorizeCore(HttpContextBase context) {
            // Perform your logic here, eventually update Roles property
        }
    }
