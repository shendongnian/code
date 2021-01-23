    private async Task<bool> EvilSaveAsync(DispatcherFrame frame)
    {
      try
      {
        return await Task.Run(() => Save());
      }
      finally
      {
        frame.Continue = false;
      }
    }
    public override void SynchronousMethodFromFramework()
    {
      var frame = new DispatcherFrame();
      var task = EvilSaveAsync(frame);
      Dispatcher.PushFrame(frame);
      return task.GetAwaiter().GetResult();
    }
