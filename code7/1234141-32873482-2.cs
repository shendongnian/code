    public class AuthorizeWritersAttribute : AuthorizeAttribute 
    {
        public AuthorizeWritersAttribute()
        {
            Roles = ConfigurationManager.AppSettings["SolutionName:AuthorizedWriters"];
            // Actually we removed the dependency on ConfigurationManager but for brevity this suffices.
        }
    }
