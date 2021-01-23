    public class DiscussionHub  : Hub
    {
      private readonly ILifetimeScope _hubLifetimeScope;
      private readonly IDiscussionService  _discussionService;
    
      public MyHub(ILifetimeScope lifetimeScope)
      {
        // Create a lifetime scope for the hub.
        _hubLifetimeScope = lifetimeScope.BeginLifetimeScope("AutofacWebRequest");
    
        // Resolve dependencies from the hub lifetime scope.
        _discussionService = _hubLifetimeScope.Resolve<IDiscussionService>();
      }
    
      protected override void Dispose(bool disposing)
      {
        // Dipose the hub lifetime scope when the hub is disposed.
        if (disposing && _hubLifetimeScope != null)
        {
          _hubLifetimeScope.Dispose();
        }
        base.Dispose(disposing);
      }
    }
