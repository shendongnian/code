    public async Task WriteAsync() {
      var tasks = new List<Task>();
      while(...) {
        tasks.Add(WriteAsync(...));
      }    
      await Task.WhenAll(tasks);
    }
