     public class CustomAuthorizeAttribute : AuthorizationFilterAttribute
        {
            public CustomAuthorizeAttribute(string users = null)
            {
                Users = users;
            }
                public string Users { get; set; } //no longer always null
        //...
        }
