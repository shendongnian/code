    public Task<string> OpenAsync (CancellationToken cancellationToken)
    {
      string uri;
      Start ();
      uri = "<your endpoint here>";
      return Task.FromResult (uri);
    }
    public static object lockOperations = new object ();
    public static bool operationsStarted = false;
    public static List<ClientAuthorizationBusCommunicationListener> pendingStarts = new List<ClientAuthorizationBusCommunicationListener> ();
    public static void StartOperations ()
    {
      lock (lockOperations)
      {
        if (!operationsStarted)
        {
          foreach (ClientAuthorizationBusCommunicationListener listener in pendingStarts)
          {
            listener.DoStart ();
          }
          operationsStarted = true;
        }
      }
    }
    private static void QueueStart (ClientAuthorizationBusCommunicationListener listener)
    {
      lock (lockOperations)
      {
        if (operationsStarted)
        {
          listener.DoStart ();
        }
        else
        {
          pendingStarts.Add (listener);
        }
      }
    }
    private void Start ()
    {
      QueueStart (this);
    }
    private void DoStart ()
    {
      ServiceBus.WatchStatusChanges (HandleStatusMessage,
        this.clientId,
        out this.subscription);
    }
