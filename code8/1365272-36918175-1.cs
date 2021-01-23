    public void Write() {
      var tasks = new List<Task>();
      while(...) {
        tasks.Add(WriteAsync(...));
      }    
      Task.WaitAll(tasks.ToArray());
    }
