    // IObservable<bool> EmergencyButtonStates { get; }
    IDisposable subscription = board.EmergencyButtonStates
        .ObserveOn(context) // Same "context" as above. Rx can also use dispatchers, too.
        .Subscribe(state =>
        {
          IsEmergencyButtonActive = state;
          // Perform other time consuming tasks ...
        });
    // Dispose "subscription" when you don't want any more events.
