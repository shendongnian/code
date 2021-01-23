    //4. AspNetUsageBaseClass Assembly
    namespace AspNetUsage
    {
        //rest of code
    
        public abstract AspNetUsageBaseClass
        {
            //rest of code
            public abstract void HttpContextIHttpContextAccessor();
        }
    }
    
    //1. AspNetUsage Assembly, Reference AspNetUsageBaseClass Assembly
    using AspNetUsage;
    public class AspNetUsage:AspNetUsageBaseClass
    {
        public override void HttpContextIHttpContextAccessor()
        {
            //HttpContext based code
        }
    }
    
    //2. AspNetUsage Assembly, Reference AspNetUsageBaseClass Assembly
    using AspNetUsage;
    public class AspNetUsage:AspNetUsageBaseClass
    {
        public override void HttpContextIHttpContextAccessor()
        {
            //IHttpContextAccessor based code
        }
    }
