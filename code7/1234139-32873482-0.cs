    public class AuthorizeWritersAttribute : AuthorizeAttribute 
    {
        public 
        {
            Roles = ConfigurationManager.AppSettings["SolutionName:AuthorizedWriters"];
            // Actually we removed the dependency on ConfigurationManager but for brevity this suffices.
        }
    }
