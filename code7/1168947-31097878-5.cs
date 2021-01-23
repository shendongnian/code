    public class GlobalExceptionMiddleware : OwinMiddleware
    {
       public GlobalExceptionMiddleware(OwinMiddleware next) : base(next)
       {
       }
    
       public override async Task Invoke(IOwinContext context)
       {
          try
          {
              await Next.Invoke(context);
          }
          catch(Exception ex)
          {
              // your handling logic
          }
       }
     }
