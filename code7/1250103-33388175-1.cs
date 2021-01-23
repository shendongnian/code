    using Microsoft.Owin;
    using System.Threading.Tasks;
    public class SniffMiddleware : OwinMiddleware
    {
        public SniffMiddleware(OwinMiddleware next): base(next)
        {
        }
        public async override Task Invoke(IOwinContext context)
        {
            string[] headersToRemove = { "Server" };
            foreach (var header in headersToRemove)
            {
                if (context.Response.Headers.ContainsKey(header))
                {
                    context.Response.Headers.Remove(header);
                }
            }
            await Next.Invoke(context);
        }
    }
