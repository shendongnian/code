    using Microsoft.Owin;
    using System.Threading.Tasks;
    
    namespace YourProject
    {
        public class HeadHandler : OwinMiddleware
        {
            public HeadHandler(OwinMiddleware next) : base(next)
            {
            }
    
            public override async Task Invoke(IOwinContext context)
            {
                if (context.Request.Method == "HEAD")
                {
                    context.Response.StatusCode = 200;
                }
                else
                {
                    await Next.Invoke(context);
                }
            }
        }
    }
