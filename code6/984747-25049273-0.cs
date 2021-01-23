    // Act
    HttpResponseMessage response = actionInvoker.InvokeActionAsync(_baseActionContext, CancellationToken.None).Result;
    // After you have obtained the returned Task object,
    // and done whatever will initiate the asynchronous activity, wait for it to complete...
    task1.Wait();  // <-- Try this
    // Assert
    Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
 
