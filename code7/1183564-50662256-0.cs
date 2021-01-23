    var webResponseTask = request.GetResponseAsync();
        
    await Task.WhenAll(webResponseTask);
    if (webResponseTask.IsFaulted)
      throw webResponseTask.Exception;
    using (var webResponse = webResponseTask.Result)
    {
    }
