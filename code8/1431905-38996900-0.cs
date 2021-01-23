    // var MyResult has a field `Header`
    var promise = new TaskCompletionSource<MyResult>();
    handlerMyEventsWithHandler(msg =>
      promise.SetResult(msg)
    );
    // Wait for 2 seconds
    if (promise.Task.Wait(2000))
    {
      var myResult = promise.Task.Result;
      Debug.Assert("my header" == myResult.Header);
    }
