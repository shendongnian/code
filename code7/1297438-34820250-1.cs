    public void DoBackGroundWork()
    {
        ChronicusContext anotherContext= new ChronicusContext();
        while (true)
        {
           if (anotherContext.PollModels.Any())
           {
              ...
           }
        }
    }
