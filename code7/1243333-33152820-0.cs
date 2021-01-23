    internal sealed class MainClass: InheritedClass
    {
      public override async Task StartAsync()
      {
        base.Start();
        var result = await TaskEx.Run(() => DoSomeWork());
        Store(result);
      }
    }
