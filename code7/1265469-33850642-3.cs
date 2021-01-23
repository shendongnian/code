    public async Task<IEnumerable<HttpResponseMessage>> GoCrazy()
    {
      var putTasks = new List<Task<HttpResponseMessage>>();
      for (var i = 0; i < 100; i++)
      {
        var task = client.PutAsync("something");
        putTasks.Add(task);
      }
      // WhenAll not WaitAll
      var result = await Task.WhenAll(putTasks);
      return result;
    }
    
