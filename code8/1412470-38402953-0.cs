    private ActionBlock<IMobileMsg> _block = new ActionBlock<IMobileMsg>(async msg =>
    {
      try
      {
        Trace.TraceInformation("Sending: {0}", msg.Name);
        await Task.Delay(1000);
        msg.SentTime = DateTime.UtcNow;
        Trace.TraceInformation("X sent at {1}: {0}", msg.Name, msg.SentTime);
      }
      catch (Exception e)
      {
        TraceException(e);
      }
    });
