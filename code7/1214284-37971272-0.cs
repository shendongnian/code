    public class SetActivityIdModule : IHttpModule {
      public void Init(HttpApplication context) {
      context.BeginRequest += (sender, args) =>
        {
          if (Trace.CorrelationManager.ActivityId == Guid.Empty) Trace.CorrelationManager.ActivityId = Guid.NewGuid();
        };
      }
      public void Dispose() {}
    }
