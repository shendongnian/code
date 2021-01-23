    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private ApplicationDbContext context = new ApplicationDbContext(); 
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // spiting different roles by ',' 
            var roles=this.Rols.Split(',');
            // rest of your code
        }
    }
