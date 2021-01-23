    private static void CallCreateAppointments(IObjectSpace os)
    {
      var config = HandyDefaults.GetConfig(os, EnumImportOrder.ReadyBy);
      using (var connect = MakeConnect(os))
      {
        var ct = new CancellationToken();
    
        // this method is already async, because it needs CancellationToken
        // to be able to cancel the task, just start it like this,
        // no need to start it inside Task.Run(...)
        var retval = CreateAppointments(connect, ct, null, config);
        // do whatever with retval
      }
    }
