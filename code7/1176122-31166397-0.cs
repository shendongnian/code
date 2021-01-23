    public class RootRedirector : IRequestStartup
    {
        public void Initialize(IPipelines pipelines, NancyContext context)
        {
            if (context.Request.Url.Path == "/")
            {
               throw new RouteExecutionEarlyExitException(new RedirectResponse("/index.html"));
            }
        }
    }
