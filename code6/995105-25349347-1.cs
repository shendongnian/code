    public class PostProcessingEventArgs
    {
      private readonly DeferralManager _deferrals;
      public PostProcessingEventArgs(DeferralManager deferrals, ...)
      {
        _deferrals = deferrals;
        ...
      }
      public IDisposable GetDeferral()
      {
        return deferrals.GetDeferral();
      }
      ...
    }
