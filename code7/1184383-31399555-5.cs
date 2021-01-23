    //set the sync context
    var thisSyncContext = new MockSynchronizationContext();
    SynchronizationContext.SetSynchronizationContext(thisSyncContext);
    thisSyncContext.Post(cb => {
      var ctx = SynchronizationContext.Current; //<-- this is not null
      var equals = thisSyncContext.Equals(ctx); //<-- this is true
    },null);
    thisSyncContext.Send(cb => {
      var ctx = SynchronizationContext.Current; //<-- this is not null
      var equals = thisSyncContext.Equals(ctx); //<-- this is true
    }, null);
