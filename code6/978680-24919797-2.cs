    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
      protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
      {
        base.ApplicationStartup(container, pipelines);
        CookieBasedSessions.Enable(pipelines);
      }
    }
