    interface IDetails { Task ProcessAsync(); }
    class Subject
    {
      private IDetails _details { get; }
      public Subject(IDetails details) { _details = details; }
      async Task SomeMethodAsync()
      {
        ...
        if (_details)
          await _details.ProcessAsync();
      }
    }
