    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private ApplicationDbContext context = new ApplicationDbContext(); 
        
        // you don't need the constrictor and private roles field  
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // spiting different roles by ',' 
            var roles=this.Rols.Split(',');
            // rest of your code
        }
    }
