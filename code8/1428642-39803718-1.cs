      public class CustomAuthorizationFilter : IDashboardAuthorizationFilter
    { 
        public bool Authorize(DashboardContext context)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                return true; 
            }
            return false; 
        }
    }
