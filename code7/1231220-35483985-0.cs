        public class SignalRvDirMiddleware : OwinMiddleware
        {
           public SignalRvDirMiddleware(OwinMiddleware next)
            : base(next)
           { }
           public override async Task Invoke(IOwinContext context)
           {
               var vdir = new PathString("/companyservice");
               PathString path = context.Request.PathBase;
               if (!path.StartsWithSegments(vdir))
               {
                  context.Request.PathBase = vdir + path;
               }
               await Next.Invoke(context);
            }
         }
